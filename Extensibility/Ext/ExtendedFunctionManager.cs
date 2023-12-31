using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibilityPackage.ExtPackage.Extensibility.Ext;

public class ExtendedFunctionManager
{
    #region variables
    List<Action> InitializeFunc = new List<Action>();
    List<Action> UpdateFunc = new List<Action>();
    List<Action> EndFunc = new List<Action>();
    public Action OnEnableAction = OnEnable;
    public Action OnDisableAction = OnDisable;
    public Action OnStartAction = OnStart;
    public Action OnUpdateAction = OnUpdate;
    public Action OnEndAction = OnEnd;
    public bool CanTick = true;
    public bool Enabled = false;
    #endregion
    #region functions
    #region StarterFunc
    static internal void OnEnable() { }
    static internal void OnDisable() { }
    static internal void OnStart() { }
    static internal void OnUpdate() { }
    static internal void OnEnd() { }
    #endregion
    #region RunFuncCode

    /// <summary>
    /// Runs the first functions that should run at the start of the project. Only use this function at the start of your code.
    /// </summary>
    #region Functions that call the events
    public void Initialize()
    {
        Enabled = true;
        OnEnableAction.Invoke();
        InitializeFunc.Clear();
        InitializeFunc.Add(OnStartAction);
        InitializeFunc[0].Invoke();
    }
    /// <summary>
    /// Runs the function that should be called once per tick. Do not place code after this. This should include your basic code;
    /// </summary>
    public void Update()
    {
        while (CanTick)
        {
            UpdateFunc.Clear();
            UpdateFunc.Add(OnUpdateAction);
            UpdateFunc[0].Invoke();
        }
        if (!CanTick)
        {
            EndUpdate();
        }
    }
    /// <summary>
    /// This function should NOT be called from a different script because it is automatically called during Update().
    /// </summary>
    internal void EndUpdate()
    {
        if (CanTick == false)
        {
            EndFunc.Clear();
            EndFunc.Add(OnEndAction);
            EndFunc[0].Invoke();
        }
    }
    public void ExecuteAll()
    {
        Initialize();
        Update();
    }
    public void BasicSetup(Action OnStartAC, Action OnUpdateAC, Action OnEndUpdateAC)
    {
        OnStartAction = OnStartAC;
        OnUpdateAction = OnUpdateAC;
        OnEndAction = OnEndUpdateAC;
    }
    public void UpdateEnd(int EndForceMode = (int)ForceMode.GentleForce)
    {
        if(EndForceMode == (int)ForceMode.GentleForce)
        {
            CanTick = false;
        }
        else if(EndForceMode == (int)ForceMode.Force)
        {
            CanTick = false;
            EndUpdate();
        }
    }
    /// <summary>
    /// returns a list of actions with the empty placeholder OnStart, OnUpdate and OnEnd functions used internally by the script.
    /// </summary>
    public List<Action> ExposeInternalFunctions()
    {
        return new List<Action>() { OnStart, OnUpdate, OnEnd };
    }
    #endregion
    #endregion
    #endregion
}
