using System;
using System.Collections.Generic;
using System.Configuration;
using VirtualLibrarity.DataWorkers;
using VirtualLibrarity.Interfaces;
using VirtualLibrarity.Models;

namespace VirtualLibAPI
{
    public class PostHandler:IPostHandler
    {
        private IReader _fr;
        private IWriter _fw;
        private IRecognizer _rec;
        public PostHandler(IReader fr, IWriter fw, IRecognizer rec)
        {
            _fr = fr;
            _fw = fw;
            _rec = rec;

        }
        public UserToLoginResponse HandlePost<F>(F face)
            where F:IFace
        {
            int id = _fr.ReadInfo();
            List<string> faces64String = _fr.ReadFaces(id);
                if (faces64String == null)
                    return new UserToLoginResponseBuilder().BuildUserToSend(Convert.ToInt16(Strings.GetString("errorCode")));
                else
                    return new UserToLoginResponseBuilder().BuildUserToSend(_rec.Recognize(faces64String, face.Image64String));
        }
        public int HandleRegisterPost(RegisterArgs regArgs)
        {
            //Kreiptis į db su regArgs.User ir id
            int id = _fr.ReadInfo();
            bool ok1,ok2;
            id++;
            ok1 =_fw.WriteFaceToFile(id, regArgs.Image);
            ok2 =_fw.WriteInfoFile(id);
            if (ok1 && ok2)
               return 0;
            else
               return Convert.ToInt16(Strings.GetString("errorCode"));
        }
       
    }
}