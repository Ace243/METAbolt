//  Copyright (c) 2008 - 2011, www.metabolt.net (METAbolt)
//  Copyright (c) 2006-2008, Paul Clement (a.k.a. Delta)
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright notice, 
//    this list of conditions and the following disclaimer in the documentation 
//    and/or other materials provided with the distribution. 

//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//  IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
//  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
//  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
//  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
//  POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Text;

namespace SLNetworkComm
{
    public class StartLocationParser
    {
        private string location;

        public StartLocationParser(string llocation)
        {
            if (llocation == null) throw new Exception("Location cannot be null.");

            this.location = llocation;
        }

        private string GetSim(string llocation)
        {
            if (!llocation.Contains("/")) return llocation;

            string[] locSplit = llocation.Split('/');
            return locSplit[0];
        }

        private int GetX(string llocation)
        {
            if (!llocation.Contains("/")) return 128;

            string[] locSplit = llocation.Split('/');

            int returnResult;
            bool stringToInt = int.TryParse(locSplit[1], out returnResult);

            if (stringToInt)
                return returnResult;
            else
                return 128;
        }

        private int GetY(string llocation)
        {
            if (!llocation.Contains("/")) return 128;

            string[] locSplit = llocation.Split('/');

            int returnResult;
            bool stringToInt = int.TryParse(locSplit[2], out returnResult);

            if (stringToInt)
                return returnResult;
            else
                return 128;
        }

        private int GetZ(string llocation)
        {
            if (!llocation.Contains("/")) return 0;

            string[] locSplit = llocation.Split('/');

            int returnResult;
            bool stringToInt = int.TryParse(locSplit[3], out returnResult);

            if (stringToInt)
                return returnResult;
            else
                return 0;
        }

        public string Sim
        {
            get { return GetSim(location); }
        }

        public int X
        {
            get { return GetX(location); }
        }

        public int Y
        {
            get { return GetY(location); }
        }

        public int Z
        {
            get { return GetZ(location); }
        }
    }
}
