using System;
using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Core.Services
{
    public delegate void ActLoggedEventHandler(object sender, ActLoggedEventArgs e);

    public class ActLoggerService
    {
        private readonly IActRepository _actRepository;
        public event ActLoggedEventHandler Logged;

        public ActLoggerService(IActRepository actRepository)
        {
            this._actRepository = actRepository;
        }

        public void LogAct(Act _act)
        {
            _actRepository.Save(_act);

            OnActLogged(new ActLoggedEventArgs(_act));
        }

        private void OnActLogged(ActLoggedEventArgs e)
        {
            if (Logged != null)
            {
                Logged(this, e);
            }
        }
    }

    public class ActLoggedEventArgs : EventArgs
    {
        public ActLoggedEventArgs(Act act)
        {
            this.Act = act;
        }
        public Act Act;
    }
}