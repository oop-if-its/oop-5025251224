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

    // TODO(Level 4): setter BatasPinjam sekarang PUBLIC sehingga siapa pun bisa
    //   mengubahnya. Ubah menjadi `protected set` supaya hanya Anggota dan kelas
    //   turunannya yang boleh mengubah. Nilai awal untuk Anggota biasa = 2.
    public int BatasPinjam { get; set; } = 2;

    public int JumlahPinjam { get; private set; }

    // TODO(Level 9): tambahkan field `private readonly LogAktivitas _log =
    //   new();` -- setiap Anggota MEMILIKI log-nya sendiri (bukan satu log
    //   bersama/static).

    // Level 9: riwayat aktivitas milik anggota ini.
    public IReadOnlyList<string> Riwayat
    {
        get
        {
            // TODO(Level 9): kembalikan isi log milik anggota ini
            //   (LogAktivitas.Semua).
            throw new NotImplementedException("Level 9 belum diimplementasikan");
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

    // TODO(Level 9): setiap peminjaman yang berhasil juga dicatat ke log:
    //   `_log.Catat($"Pinjam: {judul}")`.
    public void Pinjam(string judul)
    {
        // TODO(Level 5): judul null/kosong -> ArgumentException; JumlahPinjam
        //   sudah mencapai BatasPinjam -> InvalidOperationException; selain itu
        //   naikkan JumlahPinjam satu.
        throw new NotImplementedException("Level 5 belum diimplementasikan");
    }
}
