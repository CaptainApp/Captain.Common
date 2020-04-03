namespace Captain.Common {
  /// <summary>
  ///   Defines global behaviours on which multiple components may depend.
  /// </summary>
  public abstract class Behaviour {
    /// <summary>
    ///   Times this behaviour was locked
    /// </summary>
    private uint lockCount;

    /// <summary>
    ///   Locks the behaviour
    /// </summary>
    protected abstract void Lock();

    /// <summary>
    ///   Unlocks the behaviour
    /// </summary>
    protected abstract void Unlock();

    /// <summary>
    ///   Requests this behaviour to be locked
    /// </summary>
    public void RequestLock() {
      //Log.Trace($"requested behaviour lock (new lock count: {1 + this.lockCount})");
      if (this.lockCount++ == 0) { Lock(); }
    }

    /// <summary>
    ///   Requests this behaviour to be unlocked
    /// </summary>
    public void RequestUnlock() {
      //Log.Trace($"requested behaviour unlock (new lock count: {Math.Min(0, this.lockCount - 1)})");
      if (this.lockCount > 0 && --this.lockCount == 0) { Unlock(); }
    }
  }
}