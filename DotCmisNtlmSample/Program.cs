using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotCMIS;
using DotCMIS.Client.Impl;
using DotCMIS.Client;

namespace DotCmisNtlmSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parameters.
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters[SessionParameter.AtomPubUrl] = "http://kate:18080/alfresco/cmisatom"; // Change this to yours.
            parameters[SessionParameter.BindingType] = BindingType.AtomPub;
            parameters[SessionParameter.AuthenticationProviderClass] = "DotCMIS.Binding.NtlmAuthenticationProvider";
            
            // No need for username and password, thanks to NTLM-based SSO (Single Sign On)
            //parameters[SessionParameter.User] = "<username>";
            //parameters[SessionParameter.Password] = "<password>";

            SessionFactory factory = SessionFactory.NewInstance();
            ISession session = factory.GetRepositories(parameters)[0].CreateSession();

            // List all children of the root folder.
            IFolder rootFolder = session.GetRootFolder();
            foreach (ICmisObject cmisObject in rootFolder.GetChildren())
            {
                Console.WriteLine(cmisObject.Name);
            }

            // Don't close console.
            Console.ReadKey();
        }
    }
}
