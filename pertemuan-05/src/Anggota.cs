// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

// Kelas dasar (base class) untuk semua jenis anggota perpustakaan.
public class Anggota
{
    public string Id { get; }
    public string Nama { get; }

    // Komposisi: Anggota memiliki Alamat.
    public Alamat Alamat { get; }

    // Level 4: setter protected, hanya Anggota dan turunannya yang boleh mengubah.
    public int BatasPinjam { get; protected set; } = 2;

    public int JumlahPinjam { get; private set; }

    // Level 9: setiap Anggota MEMILIKI log-nya sendiri (bukan static).
    private readonly LogAktivitas _log = new();

    // Level 9: riwayat aktivitas milik anggota ini.
    public IReadOnlyList<string> Riwayat
    {
        get
        {
            return _log.Semua;
        }
    }

    public Anggota(string id, string nama, Alamat alamat)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id tidak boleh null, kosong, atau spasi.", nameof(id));

        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama tidak boleh null, kosong, atau spasi.", nameof(nama));

        if (alamat is null)
            throw new ArgumentNullException(nameof(alamat));

        Id = id;
        Nama = nama;
        Alamat = alamat; // referensi yang sama, tidak disalin
    }

    public string Info()
    {
        return $"{Id} - {Nama}";
    }

    public void Pinjam(string judul)
    {
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul tidak boleh null, kosong, atau spasi.", nameof(judul));

        if (JumlahPinjam >= BatasPinjam)
            throw new InvalidOperationException("Batas peminjaman sudah tercapai.");

        JumlahPinjam++;
        _log.Catat($"Pinjam: {judul}"); // Level 9: hanya peminjaman yang berhasil dicatat
    }
}
