// Copyright © Rick@AIBrain.org and Protiguous. All Rights Reserved.
// 
// This entire copyright notice and license must be retained and must be kept visible
// in any binaries, libraries, repositories, and source code (directly or derived) from
// our binaries, libraries, projects, or solutions.
// 
// This source code contained in "Form1.cs" belongs to Protiguous@Protiguous.com and
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
// Project: "WhyIUseAwait", "Form1.cs" was last formatted by Protiguous on 2019/06/23 at 10:13 AM.

namespace WhyIUseAwait {

    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using JetBrains.Annotations;

    public partial class Form1 : Form {

        public Form1() {
            this.InitializeComponent();
        }

        private static UInt64 LongCalculation( TimeSpan time, IProgress<Int32> report ) {
            var stopwatch = Stopwatch.StartNew();

            UInt64 summary = 0;
            var lastReport = 0;

            do {
                summary += 1;
                var current = ( Int32 ) stopwatch.Elapsed.TotalSeconds;

                if ( current > lastReport ) {
                    report.Report( current );
                    lastReport = current;
                }
            } while ( stopwatch.Elapsed < time );

            report.Report( 0 );

            return summary;
        }

        private void ButtonDone_Click( Object sender, EventArgs e ) {
            this.InvokeAction( this.Close );
        }

        private async void ButtonGoWith_Click( Object sender, EventArgs e ) {
            try {
                this.buttonGoWithout.Enabled = false;

                if ( this.GetValue( out var time ) ) {
                    this.Reset( time: time );
                    this.Message( "Running calculation. NOTE: Try moving this form.." );
                    var result = await Task.Run( () => LongCalculation( time, new Progress<Int32>( this.ReportProgress ) ) ).ConfigureAwait( false );
                    this.Message( $"The result is {result:N0}." );
                }
            }
            finally {
                this.buttonGoWithout.Enabled( true );
            }
        }

        private void ButtonGoWithout_Click( Object sender, EventArgs e ) {
            try {
                this.buttonGoWithout.Enabled = false;

                if ( this.GetValue( out var time ) ) {
                    this.Reset( time: time );
                    this.Message( "Running calculation. NOTE: Try moving this form.." );
                    var result = LongCalculation( time, new Progress<Int32>( this.ReportProgress ) );
                    this.Message( $"The result is {result:N0}." );
                }
            }
            finally {
                this.buttonGoWithout.Enabled( true );
            }
        }

        private void Form1_Shown( Object sender, EventArgs e ) {
            this.Message( "Ready. Press either Run button." );
        }

        private Boolean GetValue( out TimeSpan time ) {
            if ( !Int32.TryParse( this.textBoxSeconds.Text, out var seconds ) ) {
                Console.Beep();
                this.Message( "Unable to parse value. Please enter a number." );
                time = default;

                return false;
            }

            time = TimeSpan.FromSeconds( seconds );

            return true;
        }

        private void Message( [CanBeNull] String text ) {
            this.textBoxMain.Text( $"{this.textBoxMain.Text()}{Environment.NewLine}{text}".Trim() );
            this.textBoxMain.InvokeAction( () => this.textBoxMain.ScrollToCaret() );
        }

        private void ReportProgress( Int32 value ) {
            this.toolStripProgressBar1.Owner.InvokeAction( () => {
                this.toolStripProgressBar1.Value = value;
                this.toolStripProgressBar1.Owner.Refresh();
            } );
        }

        private void Reset( TimeSpan time ) {
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 1 + ( Int32 ) time.TotalSeconds;
            this.toolStripProgressBar1.Value = 0;
        }

    }

}