﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleanArchitecture.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceLocalizer {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceLocalizer() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CleanArchitecture.Application.Resources.ResourceLocalizer", typeof(ResourceLocalizer).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request model is empty.
        /// </summary>
        public static string RequestModelIsNull {
            get {
                return ResourceManager.GetString("RequestModelIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Mail address is incorrect.
        /// </summary>
        public static string UserEmailIsIncorrect {
            get {
                return ResourceManager.GetString("UserEmailIsIncorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Mail address must not be empty.
        /// </summary>
        public static string UserEmailIsRequired {
            get {
                return ResourceManager.GetString("UserEmailIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Firstname must not be empty.
        /// </summary>
        public static string UserFirstNameIsRequired {
            get {
                return ResourceManager.GetString("UserFirstNameIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Firstname must be minimum {0} characters..
        /// </summary>
        public static string UserFirstNameIsTooShort {
            get {
                return ResourceManager.GetString("UserFirstNameIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User ID  must not be empty.
        /// </summary>
        public static string UserIdIsEmpty {
            get {
                return ResourceManager.GetString("UserIdIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User ID is incorrect.
        /// </summary>
        public static string UserIdIsInvalid {
            get {
                return ResourceManager.GetString("UserIdIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lastname must not be empty.
        /// </summary>
        public static string UserLastNameIsRequired {
            get {
                return ResourceManager.GetString("UserLastNameIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lastname must be minimum {0} characters.
        /// </summary>
        public static string UserLastNameIsTooShort {
            get {
                return ResourceManager.GetString("UserLastNameIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User not found.
        /// </summary>
        public static string UserNotFound {
            get {
                return ResourceManager.GetString("UserNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must not be empty.
        /// </summary>
        public static string UserPasswordIsRequired {
            get {
                return ResourceManager.GetString("UserPasswordIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must be minimum {0} characters.
        /// </summary>
        public static string UserPasswordIsTooShort {
            get {
                return ResourceManager.GetString("UserPasswordIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username {0} already exists.
        /// </summary>
        public static string UserUsernameAlreadyExists {
            get {
                return ResourceManager.GetString("UserUsernameAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username must not be empty.
        /// </summary>
        public static string UserUsernameIsEmpty {
            get {
                return ResourceManager.GetString("UserUsernameIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username must be minimum {0} characters.
        /// </summary>
        public static string UserUsernameIsTooShort {
            get {
                return ResourceManager.GetString("UserUsernameIsTooShort", resourceCulture);
            }
        }
    }
}
