using System;
using System.Collections.Generic;
using System.Linq;
using AppKit;
using CoreFoundation;
using Foundation;

namespace Ciphers0._1
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
            }
        }
        partial void DecryptBtn(NSButton sender)
        {
            Caeser caeser = new Caeser();
            _OutputTxt.StringValue = caeser.Decrypt(Int32.Parse(_ShiftTxt.StringValue), _InputTxt.StringValue);
        }
        partial void EncryptBtn(NSButton sender)
        {
            Caeser caeser = new Caeser();
            _OutputTxt.StringValue = caeser.Encrypt(Int32.Parse(_ShiftTxt.StringValue),_InputTxt.StringValue);
        }




        partial void btnMixShit(NSButton sender)
        {
            Polybius polybius = new Polybius();
            string[,] mesh = new string[5,7];
            NSTextField[,] fields = new NSTextField[5,7]
            {{txtbox11,txtbox12,txtbox13,txtbox14,txtbox15,txtbox16,txtbox17 }
            ,{txtbox21,txtbox22,txtbox23,txtbox24,txtbox25,txtbox26,txtbox27 },
            { txtbox31,txtbox32,txtbox33,txtbox34,txtbox35,txtbox36,txtbox37 },
            { txtbox41,txtbox42,txtbox43,txtbox44,txtbox45,txtbox46,txtbox47 },
            { txtbox51,txtbox52,txtbox53,txtbox54,txtbox55,txtbox56,txtbox57 }};
            char[] polish = polybius.PolskiLow;
            int w = mesh.GetUpperBound(1) + 1;
            for (int i = 0; i < mesh.Length; ++i)
            {
                int sr = i / w;
                int sc = i % w;
                mesh[sr, sc] = polish[i].ToString();
            }
            var shuffler = new Shuffler();
            shuffler.Shuffle(mesh);
            for (int i = 0; i < fields.Length; ++i)
            {
                int sr = i / w;
                int sc = i % w;
                fields[sr, sc].StringValue = mesh[sr,sc];
            }
        }
        partial void btnPolybEncry(NSButton sender)
        {
            if (txtbox11.StringValue==string.Empty)
            {
                btnMixShit(sender);
            }
            Polybius polybius = new Polybius();
            NSTextField[,] fields = new NSTextField[5, 7]
            {{txtbox11,txtbox12,txtbox13,txtbox14,txtbox15,txtbox16,txtbox17 }
            ,{txtbox21,txtbox22,txtbox23,txtbox24,txtbox25,txtbox26,txtbox27 },
            { txtbox31,txtbox32,txtbox33,txtbox34,txtbox35,txtbox36,txtbox37 },
            { txtbox41,txtbox42,txtbox43,txtbox44,txtbox45,txtbox46,txtbox47 },
            { txtbox51,txtbox52,txtbox53,txtbox54,txtbox55,txtbox56,txtbox57 }};
            string[,] emptyS = new string[5, 7];
            for (int k = 0; k < emptyS.GetLength(0); k++)
            {
                for (int l = 0; l < emptyS.GetLength(1); l++)
                {
                    emptyS[k, l] = fields[k, l].StringValue;
                }
            }
            polyOutput.StringValue = polybius.Encrypt(poLyInput.StringValue, emptyS);
        }
        partial void btnPolyDecry(NSButton sender)
        {
            if (txtbox11.StringValue==string.Empty)
            {
                btnMixShit(sender);
            }
            Polybius polybius = new Polybius();
            NSTextField[,] fields = new NSTextField[5, 7]
            {{txtbox11,txtbox12,txtbox13,txtbox14,txtbox15,txtbox16,txtbox17 }
            ,{txtbox21,txtbox22,txtbox23,txtbox24,txtbox25,txtbox26,txtbox27 },
            { txtbox31,txtbox32,txtbox33,txtbox34,txtbox35,txtbox36,txtbox37 },
            { txtbox41,txtbox42,txtbox43,txtbox44,txtbox45,txtbox46,txtbox47 },
            { txtbox51,txtbox52,txtbox53,txtbox54,txtbox55,txtbox56,txtbox57 }};
            string[,] emptyS = new string[5, 7];
            for (int k = 0; k < emptyS.GetLength(0); k++)
            {
                for (int l = 0; l < emptyS.GetLength(1); l++)
                {
                    emptyS[k, l] = fields[k, l].StringValue;
                }
            }
            polyOutput.StringValue = polybius.Decrypt(poLyInput.StringValue, emptyS);
        }

        partial void btnEncVign(NSButton sender)
        {
            Vigener vigener = new Vigener();
            txtOutVign.StringValue = vigener.Encrypt(txtInputVign.StringValue, txtKeyVign.StringValue);
        }

        partial void btnDecrVign(NSButton sender)
        {
            Vigener vigener = new Vigener();
            txtOutVign.StringValue = vigener.Decrypt(txtInputVign.StringValue, txtKeyVign.StringValue);
        }
    }
}