﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleCSharpinDepth.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConsoleCSharpinDepth.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt; 
        ///&lt;Data&gt;
        ///&lt;Products&gt;
        ///&lt;Product Name=&quot;West Side Story&quot; Price=&quot;9.99&quot; SupplierID=&quot;1&quot; /&gt;
        ///&lt;Product Name=&quot;Assassins&quot; Price=&quot;14.99&quot; SupplierID=&quot;2&quot; /&gt;
        ///&lt;Product Name=&quot;Frogs&quot; Price=&quot;13.99&quot; SupplierID=&quot;1&quot; /&gt;
        ///&lt;Product Name=&quot;Sweeney Todd&quot; Price=&quot;10.99&quot; SupplierID=&quot;3&quot; /&gt;
        ///&lt;/Products&gt;
        ///&lt;Suppliers&gt;
        ///&lt;Supplier Name=&quot;Solely Sondheim&quot; SupplierID=&quot;1&quot; /&gt;
        ///&lt;Supplier Name=&quot;CD-by-CD-by-Sondheim&quot; SupplierID=&quot;2&quot; /&gt;
        ///&lt;Supplier Name=&quot;Barbershop CDs&quot; SupplierID=&quot;3&quot; /&gt;
        ///&lt;/Suppliers&gt;
        ///&lt;/Data&gt;.
        /// </summary>
        internal static string Data {
            get {
                return ResourceManager.GetString("Data", resourceCulture);
            }
        }
    }
}