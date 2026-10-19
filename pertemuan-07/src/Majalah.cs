// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan07;

// TODO(Level 3): implementasikan IDapatDipinjam.
// TODO(Level 8): implementasikan IDapatDicetak dengan cara EKSPLISIT (`string
//   IDapatDicetak.Cetak()`) -- method-nya tidak muncul di tipe Majalah, hanya
//   lewat variabel bertipe IDapatDicetak.
// Majalah TIDAK mengimplementasikan IDapatDiperpanjang.
public class Majalah : Item
{
    public int Edisi { get; }

    // SUDAH LENGKAP -- jangan diubah.
    public Majalah(string judul, int edisi) : base(judul)
    {
        if (edisi <= 0)
            throw new ArgumentOutOfRangeException(nameof(edisi), "Edisi harus positif.");
        Edisi = edisi;
    }

    // TODO(Level 2): tulis `public override int HitungDenda(int hariTerlambat)`
    //   -- Rp500 per hari (hariTerlambat <= 0 -> 0).

    // TODO(Level 2): tulis `public override int MasaPinjamHari` -> 3.

    // TODO(Level 3): implementasi IDapatDipinjam (lihat petunjuk di Buku).

    // TODO(Level 8): implementasi EKSPLISIT IDapatDicetak.Cetak() -> "Majalah:
    //   <Judul> edisi <Edisi>".
}
