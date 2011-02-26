using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel.DomainServices.Client.ApplicationServices;

namespace GetLit.RIA
{
    public sealed partial class WebContext : WebContextBase
    {

        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion


        /// <summary>
        /// Initializes a new instance of the WebContext class.
        /// </summary>
        public WebContext()
        {
            this.OnCreated();
            //WindowsAuthentication newWindowsAuthentication = new WindowsAuthentication();
            //newWindowsAuthentication.DomainContextType = "GetLit.RIA.Server.AuthenticationContext, GetLit.RIA.Server, Version=1.0.0.0";
            //this.Authentication = newWindowsAuthentication;
        }

        /// <summary>
        /// Gets the context that is registered as a lifetime object with the current application.
        /// </summary>
        /// <exception cref="InvalidOperationException"> is thrown if there is no current application,
        /// no contexts have been added, or more than one context has been added.
        /// </exception>
        /// <seealso cref="System.Windows.Application.ApplicationLifetimeObjects"/>
        public new static WebContext Current
        {
            get
            {
                return ((WebContext)(WebContextBase.Current));
            }
        }

        /// <summary>
        /// Gets a user representing the authenticated identity.
        /// </summary>
        //public new User User
        //{
        //    get
        //    {
        //        return ((User)(base.User));
        //    }
        //}


    }
}
