﻿#region License
/*Copyright (c) 2013, Karl Sparwald
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that 
the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following 
disclaimer.

* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the 
following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS
OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED 
OF THE POSSIBILITY OF SUCH DAMAGE.*/
#endregion

using System;
using System.Text.RegularExpressions;

namespace OnkyoAdapter.Onkyo.Command
{
    internal class NetKeyboard : CommandBase
    {

        public static NetKeyboard Send(string psKeyboradInput, DeviceInfo poDevice)
        {
            if (String.IsNullOrEmpty(psKeyboradInput))
                throw new ArgumentException("psKeyboradInput is null or empty.", "psKeyboradInput");
            if (psKeyboradInput.Length > 128)
                throw new ArgumentException("psKeyboradInput is greater than 128 letters.", "psKeyboradInput");

            return new NetKeyboard()
            {
                CommandMessage = "NKY{0}".FormatWith(psKeyboradInput)
            };
        }

        #region Constructor / Destructor

        internal NetKeyboard()
        { }

        #endregion

        public EKeyboardCategory Category { get; private set; }

        public override bool Match(string psStatusMessage)
        {
            var loMatch = Regex.Match(psStatusMessage, @"!1NKY(.*)");
            if (loMatch.Success)
            {
                this.Category = loMatch.Groups[1].Value.FromDescription<EKeyboardCategory>();
                return true;
            }
            return false;
        }
    }

}
