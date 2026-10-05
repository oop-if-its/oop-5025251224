// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

// Komposisi: Perpustakaan MEMILIKI kumpulan Anggota. Karena Mahasiswa dan Dosen
// adalah Anggota, satu daftar bertipe Anggota bisa menampung keduanya.
public class Perpustakaan
{
    private readonly List<Anggota> _anggota = new();

    public int JumlahAnggota => _anggota.Count;

    public void Daftarkan(Anggota anggota)
    {
        if (anggota is null)
            throw new ArgumentNullException(nameof(anggota));

        if (Cari(anggota.Id) is not null)
            throw new InvalidOperationException($"Anggota dengan Id '{anggota.Id}' sudah terdaftar.");

        _anggota.Add(anggota);
    }

    public Anggota? Cari(string id)
    {
        foreach (var a in _anggota)
        {
            if (a.Id == id)
                return a;
        }

        return null;
    }

    public int JumlahMahasiswa()
    {
        // `is` ikut menghitung turunan, jadi Asisten terhitung sebagai Mahasiswa.
        return _anggota.Count(a => a is Mahasiswa);
    }

    public int JumlahDosen()
    {
        return _anggota.Count(a => a is Dosen);
    }
}
