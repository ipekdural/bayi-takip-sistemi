-- Il tablosu
CREATE TABLE public.Il (
    plaka_kodu INT PRIMARY KEY,
    il_adi VARCHAR(255) NOT NULL
);

-- Ilce tablosu
CREATE TABLE public.Ilce (
    posta_kodu INT PRIMARY KEY,
    ilce_adi VARCHAR(255) NOT NULL,
    il_id INT REFERENCES public.Il(plaka_kodu) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Iletisim tablosu
CREATE TABLE public.Iletisim (
    iletisim_id SERIAL PRIMARY KEY,
    telefon VARCHAR(20) NOT NULL,
    mail VARCHAR(255) NOT NULL
);

-- Adres tablosu
CREATE TABLE public.Adres (
    adres_id SERIAL PRIMARY KEY,
    adres TEXT NOT NULL,
    ilce_id INT REFERENCES public.Ilce(posta_kodu) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Musteri tablosu
CREATE TABLE public.Musteri (
    musteri_id SERIAL PRIMARY KEY,
    ad VARCHAR(255) NOT NULL,
    soyad VARCHAR(255) NOT NULL
);

-- Hizmetler tablosu
CREATE TABLE public.Hizmetler (
    hizmet_id SERIAL PRIMARY KEY,
    ad VARCHAR(255) NOT NULL,
    fiyat DECIMAL(10, 2) NOT NULL,
    aciklama TEXT
);

-- Personel tablosu
CREATE TABLE public.Personel (
    personel_id SERIAL PRIMARY KEY,
    ad VARCHAR(255) NOT NULL,
    soyad VARCHAR(255) NOT NULL,
    telefon VARCHAR(20) NOT NULL
);



-- Bayi tablosu
CREATE TABLE public.Bayi (
    bayi_id SERIAL PRIMARY KEY,
    iletisim_id INT,
    adres_id INT,
    CONSTRAINT bayiUnique UNIQUE(bayi_id),
    CONSTRAINT bayiIletisimFK FOREIGN KEY (iletisim_id) REFERENCES public.Iletisim(iletisim_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT bayiAdresFK FOREIGN KEY (adres_id) REFERENCES public.Adres(adres_id) ON DELETE NO ACTION ON UPDATE NO ACTION
   
);
-- Yonetici tablosu
CREATE TABLE public.Yonetici (
    personel_id INT PRIMARY KEY REFERENCES public.Personel(personel_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    bayi_id INT REFERENCES public.Bayi(bayi_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);
-- Pozisyon tablosu
CREATE TABLE public.Pozisyon (
    pozisyon_id SERIAL PRIMARY KEY,
    ad VARCHAR(255) NOT NULL,
    maas DECIMAL(10, 2) NOT NULL
);


-- Calisan tablosu
CREATE TABLE public.Calisan (
    personel_id INT REFERENCES public.Personel(personel_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    bayi_id INT REFERENCES public.Bayi(bayi_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    pozisyon_id INT REFERENCES public.Pozisyon(pozisyon_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    PRIMARY KEY (personel_id, bayi_id)
);


-- Ciro tablosu
CREATE TABLE public.Ciro (
    ciro_id SERIAL PRIMARY KEY,
    bayi_id INT REFERENCES public.Bayi(bayi_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    ciro_miktari DECIMAL(10, 2) NOT NULL,
    tarih DATE
);

-- Gelir tablosu
CREATE TABLE public.Gelir (
    gelir_id SERIAL PRIMARY KEY,
    ciro_id INT REFERENCES public.Ciro(ciro_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    aciklama TEXT,
    toplam_gelir DECIMAL(10, 2) NOT NULL
);

-- Gider tablosu
CREATE TABLE public.Gider (
    gider_id SERIAL PRIMARY KEY,
    ciro_id INT REFERENCES public.Ciro(ciro_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    aciklama TEXT,
    toplam_gider DECIMAL(10, 2) NOT NULL
);

-- Randevu tablosu
CREATE TABLE public.Randevu (
    randevu_id SERIAL PRIMARY KEY,
    musteri_id INT REFERENCES public.Musteri(musteri_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    bayi_id INT,
    personel_id INT,
    tarih DATE,
    hizmet_id INT REFERENCES public.Hizmetler(hizmet_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);
