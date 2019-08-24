namespace WhyIUseAwait {

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using JetBrains.Annotations;

    public static class Extensions {

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
    }
}