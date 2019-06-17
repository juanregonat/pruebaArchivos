using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaArchivos3
{
    public sealed class InPlaceBitMapMetadataWriter : System.Windows.Media.Imaging.BitmapMetadata
    {

        Stream pngStream = new System.IO.FileStream("smiley.png", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        PngBitmapDecoder pngDecoder = new PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
        BitmapFrame pngFrame = pngDecoder.Frames[0];
        InPlaceBitmapMetadataWriter pngInplace = pngFrame.CreateInPlaceBitmapMetadataWriter();            
        if (pngInplace.TrySave() == true)
            { pngInplace.SetQuery("/Text/Description", "Have a nice day."); }
        pngStream.Close();

    }



    public sealed class InPlaceBitmapMetadataWriter : System.Windows.Media.Imaging.BitmapMetadata


    Stream pngStream = new System.IO.FileStream("smiley.png", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            PngBitmapDecoder pngDecoder = new PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
    BitmapFrame pngFrame = pngDecoder.Frames[0];
    InPlaceBitmapMetadataWriter pngInplace = pngFrame.CreateInPlaceBitmapMetadataWriter();
            if (pngInplace.TrySave() == true)
            { pngInplace.SetQuery("/Text/Description", "Have a nice day."); }
    pngStream.Close();
}
