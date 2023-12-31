using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibilityPackage.ExtPackage.Extensibility.ExperimentalExt;

public abstract class UnScript
{
    public bool CanTick = true;
    public float FixedUpdateInterval = 0.0025f;
    #region User scriptable functions
    public virtual void OnStart(dynamic[]? args = null) { }
    public virtual void OnUpdate(dynamic[]? args = null) { }
    public virtual void OnFixedUpdate(dynamic[]? args = null) { }
    public virtual void OnUpdateEnd(dynamic[]? args = null) { }
    #endregion
    #region Publicstatic functions
    #endregion
    #region RunUserFunctionsFunc
    public void Start(dynamic[]? args = null)
    {
        if (args == null)
        {
            OnStart();
        }
        else
        {
            OnStart(args);
        }
    }
    public void Update(dynamic[]? args = null)
    {
        if (args == null)
        {
            while (CanTick)
            {
                OnUpdate();
                Thread.Sleep((int)FixedUpdateInterval);
                OnFixedUpdate();
            }
        }
        else
        {
            while (CanTick)
            {
                OnUpdate(args);
                Thread.Sleep((int)FixedUpdateInterval);
                OnFixedUpdate();
            }
        }
        if (!CanTick)
        {
            UpdateEnd();
        }
    }
    public void UpdateEnd(dynamic[]? args = null)
    {
        if (args == null)
        {
            OnUpdateEnd();
        }
        else
        {
            OnUpdateEnd(args);
        }
    }
    #endregion
    #region EaseOfUse Functions
    public void StartApplicationLifeCycle(dynamic[]? Startargs = null, dynamic[]? Updateargs = null, dynamic[]? EndUpdateargs = null)
    {
        Start(Startargs);
        Update(Updateargs);
    }
    #endregion
}