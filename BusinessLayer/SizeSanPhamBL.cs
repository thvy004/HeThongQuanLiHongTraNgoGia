using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

public class SizeSanPhamBL
{
    private SizeSanPhamDL dl = new SizeSanPhamDL();

    public List<SizeSanPhamDTO> GetSizeList()
    {
        return dl.GetSizeList();
    }

    public void AddSize(SizeSanPhamDTO size)
    {
        dl.AddSize(size);
    }

    public void UpdateSize(SizeSanPhamDTO size)
    {
        dl.UpdateSize(size);
    }

    public void DeleteSize(int maSize)
    {
        dl.DeleteSize(maSize);
    }
}

