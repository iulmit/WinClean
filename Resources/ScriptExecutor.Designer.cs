//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaphaëlBardini.WinClean.Resources {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ScriptExecutionWizard {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ScriptExecutionWizard() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RaphaëlBardini.WinClean.Resources.ScriptExecutor", typeof(ScriptExecutionWizard).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CultureInfo.CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Restart required.
        /// </summary>
        internal static string CompletedPageCaption {
            get {
                return ResourceManager.GetString("CompletedPageCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {0} scripts were executed successfully in {1:g}.
        ///
        ///Further debloating solutions:
        ///
        ///Winaero Tweaker - Appearance Customization
        ///O&amp;O ShutUp10 - Confidentiality and privacy protection
        ///TCPOptimizer - Network optimizations.
        /// </summary>
        internal static string CompletedPageExpander {
            get {
                return ResourceManager.GetString("CompletedPageExpander", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Cleaning completed.
        /// </summary>
        internal static string CompletedPageHeading {
            get {
                return ResourceManager.GetString("CompletedPageHeading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à To validate the changes, it is recommended to restart the system..
        /// </summary>
        internal static string CompletedPageText {
            get {
                return ResourceManager.GetString("CompletedPageText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Cleaning {0:p0} complete.
        /// </summary>
        internal static string ProgressPageCaption {
            get {
                return ResourceManager.GetString("ProgressPageCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Current script : {0}
        ///Time elapsed : {1:g}.
        /// </summary>
        internal static string ProgressPageExpander {
            get {
                return ResourceManager.GetString("ProgressPageExpander", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Scripts are executing. Console windows may appear. This operation may take some time..
        /// </summary>
        internal static string ProgressPageText {
            get {
                return ResourceManager.GetString("ProgressPageText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à When the operation is complete, automatically restart.
        /// </summary>
        internal static string ProgressPageVerification {
            get {
                return ResourceManager.GetString("ProgressPageVerification", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Restart.
        /// </summary>
        internal static string RestartVerb {
            get {
                return ResourceManager.GetString("RestartVerb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {0} - Scripts execution.
        /// </summary>
        internal static string ScriptExecution {
            get {
                return ResourceManager.GetString("ScriptExecution", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Before starting the operation, please confirm :.
        /// </summary>
        internal static string WarningPageHeading {
            get {
                return ResourceManager.GetString("WarningPageHeading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The computer is on AC power
        ///- The computer must remain on AC power throughout the operation in order to avoid a system failure.
        ///
        ///I saved any unsaved work
        ///- The operation will be completed by restarting the computer. Save any unsaved document.
        ///
        ///I closed any non-essential program
        ///- In order to avoid conflicts, quit any non-essential application..
        /// </summary>
        internal static string WarningPageText {
            get {
                return ResourceManager.GetString("WarningPageText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à I&apos;m ready to continue.
        /// </summary>
        internal static string WarningPageVerification {
            get {
                return ResourceManager.GetString("WarningPageVerification", resourceCulture);
            }
        }
    }
}
