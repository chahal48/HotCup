using System;
using InterfaceLayer;
using ProcessLayer;

namespace UserInterface
{
    public class Cls_UserInterface
    {
        //Cls_ProcessLayer Obj_ProcessLayer = new Cls_ProcessLayer();
        ILoginInterface myobj = Cls_ProcessLayer.stratLoginProc();
        
    }
}
