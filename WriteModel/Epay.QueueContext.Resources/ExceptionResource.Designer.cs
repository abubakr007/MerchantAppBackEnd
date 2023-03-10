//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epay.QueueContext.Resources {
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
    public class ExceptionResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Epay.QueueContext.Resources.ExceptionResource", typeof(ExceptionResource).Assembly);
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
        ///   Looks up a localized string similar to Sumation of Prices in details does&apos;t match total amount..
        /// </summary>
        public static string AmountNotMachesQueueDetails {
            get {
                return ResourceManager.GetString("AmountNotMachesQueueDetails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only created status queue can be approved..
        /// </summary>
        public static string ApproveNoneCreatedQueueStatus {
            get {
                return ResourceManager.GetString("ApproveNoneCreatedQueueStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Smart card and normal discount can&apos;t be used at the same time..
        /// </summary>
        public static string BothDiscountUsage {
            get {
                return ResourceManager.GetString("BothDiscountUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Detail not found..
        /// </summary>
        public static string DetailNotFound {
            get {
                return ResourceManager.GetString("DetailNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid discount..
        /// </summary>
        public static string InvalidDiscount {
            get {
                return ResourceManager.GetString("InvalidDiscount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid open Price..
        /// </summary>
        public static string InvalidOpenPrice {
            get {
                return ResourceManager.GetString("InvalidOpenPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid quantity..
        /// </summary>
        public static string InvalidQuantity {
            get {
                return ResourceManager.GetString("InvalidQuantity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Queue status is not valid..
        /// </summary>
        public static string InvalidQueueStatus {
            get {
                return ResourceManager.GetString("InvalidQueueStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requester is not choosen properly.
        /// </summary>
        public static string InvalidValueForRequestedBy {
            get {
                return ResourceManager.GetString("InvalidValueForRequestedBy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paid queue couldn&apos;t be modified..
        /// </summary>
        public static string PaidQueueEditing {
            get {
                return ResourceManager.GetString("PaidQueueEditing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product price not found. please check merchant products..
        /// </summary>
        public static string ProductPriceNotFound {
            get {
                return ResourceManager.GetString("ProductPriceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Item Cannot Be Deleted, Queue must have at least one Item..
        /// </summary>
        public static string QueueDetailCannotBeDeleted {
            get {
                return ResourceManager.GetString("QueueDetailCannotBeDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Queue must have at least one detail..
        /// </summary>
        public static string QueueDetailEmpty {
            get {
                return ResourceManager.GetString("QueueDetailEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Queue details has duplicate products..
        /// </summary>
        public static string QueueDetailsHasDuplicateProduct {
            get {
                return ResourceManager.GetString("QueueDetailsHasDuplicateProduct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Queue details couldn&apos;t be empty..
        /// </summary>
        public static string QueueDetailsIsNull {
            get {
                return ResourceManager.GetString("QueueDetailsIsNull", resourceCulture);
            }
        }
    }
}
