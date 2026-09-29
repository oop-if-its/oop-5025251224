// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Perpustakaan
{
    // TODO(Level 7): koleksi di bawah ini PUBLIK -- pihak luar bisa Add/Clear
    //   seenaknya, melewati aturan Tambah(). Simpan daftar di field PRIVATE
    //   (List<Buku>) dan ekspos DaftarBuku sebagai properti read-only bertipe
    //   IReadOnlyList<Buku> (atau IReadOnlyCollection/IEnumerable) yang tidak
    //   bisa dipakai untuk mengubah koleksi asli.
    private readonly List<Buku> _daftarBuku = new();

    public IReadOnlyList<Buku> DaftarBuku => _daftarBuku.AsReadOnly();

    public int JumlahJudul => DaftarBuku.Count;

    public void Tambah(Buku buku)
    {
        // TODO(Level 7): buku null -> ArgumentNullException; ISBN yang sudah ada
        //   di koleksi -> InvalidOperationException; selain itu tambahkan ke
        //   koleksi.
        if (buku == null)
        {
            throw new ArgumentNullException(nameof(buku));
        }

        if (Cari(buku.Isbn) != null)
        {
            throw new InvalidOperationException("ISBN sudah terdaftar.");
        }

        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        // TODO(Level 7): kembalikan buku dengan Isbn yang sama persis (apa
        //   adanya, tanpa normalisasi), atau null kalau tidak ada.
        foreach (var b in _daftarBuku)
        {
            if (b.Isbn == isbn)
            {
                return b;
            }
        }

        return null;
    }

    public void PinjamBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): "Tell, don't ask" -- Perpustakaan memutuskan semuanya.
        //   akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.Denda > 0 -> InvalidOperationException;
        //   akun.JumlahPinjamanAktif sudah sama dengan AkunAnggota.MaksPinjaman
        //   -> InvalidOperationException; selain itu panggil buku.Pinjam()
        //   (boleh melempar kalau stok habis) lalu akun.CatatPinjam().
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun));
        }

        var buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku dengan ISBN tersebut tidak ditemukan.", nameof(isbn));
        }

        if (akun.Denda > 0)
        {
            throw new InvalidOperationException("Akun masih memiliki denda yang belum dibayar.");
        }

        if (akun.JumlahPinjamanAktif == AkunAnggota.MaksPinjaman)
        {
            throw new InvalidOperationException("Akun sudah mencapai batas maksimum pinjaman.");
        }

        buku.Pinjam();
        akun.CatatPinjam();
    }

    public void KembalikanBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.JumlahPinjamanAktif = 0 ->
        //   InvalidOperationException; selain itu panggil buku.Kembalikan() lalu
        //   akun.CatatKembali().
        if (akun == null)
        {
            throw new ArgumentNullException(nameof(akun));
        }

        var buku = Cari(isbn);
        if (buku == null)
        {
            throw new ArgumentException("Buku dengan ISBN tersebut tidak ditemukan.", nameof(isbn));
        }

        if (akun.JumlahPinjamanAktif == 0)
        {
            throw new InvalidOperationException("Akun tidak memiliki pinjaman aktif untuk dikembalikan.");
        }

        buku.Kembalikan();
        akun.CatatKembali();
    }
}
