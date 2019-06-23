// Copyright © Rick@AIBrain.org and Protiguous. All Rights Reserved.
// 
// This entire copyright notice and license must be retained and must be kept visible
// in any binaries, libraries, repositories, and source code (directly or derived) from
// our binaries, libraries, projects, or solutions.
// 
// This source code contained in "Extensions.cs" belongs to Protiguous@Protiguous.com and
// Rick@AIBrain.org unless otherwise specified or the original license has
// been overwritten by formatting.
// (We try to avoid it from happening, but it does accidentally happen.)
// 
// Any unmodified portions of source code gleaned from other projects still retain their original
// license and our thanks goes to those Authors. If you find your code in this source code, please
// let us know so we can properly attribute you and include the proper license and/or copyright.
// 
// If you want to use any of our code, you must contact Protiguous@Protiguous.com or
// Sales@AIBrain.org for permission and a quote.
// 
// Donations are accepted (for now) via
//     bitcoin:1Mad8TxTqxKnMiHuZxArFvX8BuFEB9nqX2
//     paypal@AIBrain.Org
//     (We're still looking into other solutions! Any ideas?)
// 
// =========================================================
// Disclaimer:  Usage of the source code or binaries is AS-IS.
//    No warranties are expressed, implied, or given.
//    We are NOT responsible for Anything You Do With Our Code.
//    We are NOT responsible for Anything You Do With Our Executables.
//    We are NOT responsible for Anything You Do With Your Computer.
// =========================================================
// 
// Contact us by email if you have any questions, helpful criticism, or if you would like to use our code in your project(s).
// For business inquiries, please contact me at Protiguous@Protiguous.com
// 
// Our website can be found at "https://Protiguous.com/"
// Our software can be found at "https://Protiguous.Software/"
// Our GitHub address is "https://github.com/Protiguous".
// Feel free to browse any source code we *might* make available.
// 
// Project: "WhyIUseAwait", "Extensions.cs" was last formatted by Protiguous on 2019/06/23 at 9:33 AM.

namespace WhyIUseAwait {

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using JetBrains.Annotations;

    public static class Extensions {

        /// <summary>
        ///     <para>Perform an <see cref="Action" /> on the control's thread.</para>
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"> </param>
        /// <seealso />
        public static void InvokeAction( this Control control, Action action ) {
            if ( control == null ) {
                throw new ArgumentNullException( nameof( control ) );
            }

            if ( action == null ) {
                throw new ArgumentNullException( nameof( action ) );
            }

            if ( control.InvokeRequired ) {
                if ( !control.IsDisposed ) {
                    control.Invoke( action );
                }
            }
            else {
                action();
            }
        }

        /// <summary>
        ///     <para>Works like the SQL "nullif" function.</para>
        ///     <para>
        ///         If <paramref name="left" /> is equal to <paramref name="right" /> then return null for classes or the default
        ///         value for
        ///         value types.
        ///     </para>
        ///     <para>Otherwise return <paramref name="left" />.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"> </param>
        /// <param name="right"></param>
        /// <returns></returns>
        [CanBeNull]
        [DebuggerStepThrough]
        public static T NullIf<T>( [NotNull] this T left, T right ) => Comparer<T>.Default.Compare( left, right ) == 0 ? default : left;

        /// <summary>
        ///     <para>Safely get the <see cref="Control.Text" /> of a <see cref="Control" /> across threads.</para>
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [CanBeNull]
        public static String Text( [NotNull] this Control control ) {
            if ( control == null ) {
                throw new ArgumentNullException( paramName: nameof( control ) );
            }

            if ( !control.IsDisposed ) {

                if ( !control.InvokeRequired ) {
                    return control.Text;
                }

                if ( control.Invoke( new Func<String>( () => control.Text ) ) is String s ) {
                    return s;
                }
            }

            return default;
        }

        /// <summary>
        ///     <para>Safely set the <see cref="Control.Text" /> of a control across threads.</para>
        /// </summary>
        /// <remarks></remarks>
        /// <param name="control"></param>
        /// <param name="value">  </param>
        public static void Text( [NotNull] this Control control, [CanBeNull] String value ) {
            if ( control == null ) {
                throw new ArgumentNullException( paramName: nameof( control ) );
            }

            control.InvokeAction( () => {
                if ( !control.IsDisposed ) {
                    control.Text = value;
                    control.Update();
                }
            } );
        }

        /// <summary>
        ///     Safely set the <see cref="Control.Enabled" /> of the control across threads.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value">  </param>
        public static void Enabled( [NotNull] this Control control, Boolean value ) {
            if ( control == null ) {
                throw new ArgumentNullException( paramName: nameof( control ) );
            }

            control.InvokeAction( () => {
                if ( !control.IsDisposed ) {
                    control.Enabled = value;

                    control.Refresh();

                }

            } );
        }

    }

}