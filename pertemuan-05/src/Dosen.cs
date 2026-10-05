// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

public class Dosen : Anggota
{
    public string Nip { get; }

    // TODO(Level 4): Dosen boleh meminjam maksimal 10 buku -- atur BatasPinjam =
    //   10 di konstruktor ini.
    public Dosen(string id, string nama, Alamat alamat, string nip)
        : base(id, nama, alamat)
    {
        if (string.IsNullOrWhiteSpace(nip))
            throw new ArgumentException("Nip tidak boleh null, kosong, atau spasi.", nameof(nip));

        Nip = nip;
        BatasPinjam = 10;
    }

    public string InfoLengkap()
    {
        // TODO(Level 7): "<Info()> | NIP: <Nip> | Alamat: <Alamat>".
        throw new NotImplementedException("Level 7 belum diimplementasikan");
    }
}
