  CREATE OR REPLACE FUNCTION yonetici_trigger_function()
  RETURNS TRIGGER AS $$
  BEGIN
      -- Your trigger logic goes here
      -- For example, you can print a message to the server log
      RAISE NOTICE 'Yonetici tablosu % tarihinde değiştirildi', NOW();
      RETURN NEW;
  END;
  $$ LANGUAGE plpgsql;

  CREATE TRIGGER yonetici_trigger
  AFTER INSERT OR UPDATE OR DELETE ON public.Yonetici
  FOR EACH ROW
  EXECUTE FUNCTION yonetici_trigger_function();





  CREATE OR REPLACE FUNCTION bayi_guncelle_trigger_function()
RETURNS TRIGGER AS $$
BEGIN
    -- Güncellenen Bayi'nin bayi_id değerini al
    DECLARE updated_bayi_id INTEGER;
    updated_bayi_id := NEW.bayi_id;

    -- Yapılan güncelleme işlemini loglamak için bir kayıt ekle
    INSERT INTO public.Bayi_Guncelleme_Log(bayi_id, tarih)
    VALUES (updated_bayi_id, CURRENT_TIMESTAMP);

    -- Diğer işlemleri buraya ekleyebilirsiniz

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Tetikleyiciyi oluştur
CREATE TRIGGER bayi_guncelle_trigger
AFTER UPDATE ON public.Bayi
FOR EACH ROW
EXECUTE FUNCTION bayi_guncelle_trigger_function();




CREATE OR REPLACE FUNCTION ciro_trigger_function()
RETURNS TRIGGER AS $$
BEGIN
    -- Eğer yeni bir kayıt ekleniyorsa
    IF TG_OP = 'INSERT' THEN
        INSERT INTO public.Ciro (ciro_id, islem_tipi, tarih)
        VALUES (NEW.ciro_id, 'INSERT', CURRENT_TIMESTAMP);
    -- Eğer bir kayıt güncelleniyorsa
    ELSIF TG_OP = 'UPDATE' THEN
        INSERT INTO public.Ciro (ciro_id, islem_tipi, tarih)
        VALUES (NEW.ciro_id, 'UPDATE', CURRENT_TIMESTAMP);
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Tetikleyiciyi oluştur
CREATE TRIGGER ciro_trigger
AFTER INSERT OR UPDATE ON public.Ciro
FOR EACH ROW
EXECUTE FUNCTION ciro_trigger_function();




CREATE OR REPLACE FUNCTION hizmetler_trigger_function()
RETURNS TRIGGER AS $$
BEGIN
    -- Eğer günlük tablo mevcutsa
    IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'hizmetler_log') THEN
        -- Eğer yeni bir kayıt ekleniyorsa
        IF TG_OP = 'INSERT' THEN
            INSERT INTO hizmetler_log (hizmet_id, ad, fiyat, aciklama, islem_tipi)
            VALUES (NEW.hizmet_id, NEW.ad, NEW.fiyat, NEW.aciklama, 'INSERT');
        -- Eğer bir kayıt güncelleniyorsa
        ELSIF TG_OP = 'UPDATE' THEN
            INSERT INTO hizmetler_log (hizmet_id, ad, fiyat, aciklama, islem_tipi)
            VALUES (NEW.hizmet_id, NEW.ad, NEW.fiyat, NEW.aciklama, 'UPDATE');
        -- Eğer bir kayıt siliniyorsa
        ELSIF TG_OP = 'DELETE' THEN
            INSERT INTO hizmetler_log (hizmet_id, ad, fiyat, aciklama, islem_tipi)
            VALUES (OLD.hizmet_id, OLD.ad, OLD.fiyat, OLD.aciklama, 'DELETE');
        END IF;
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER hizmetler_trigger
AFTER INSERT OR UPDATE OR DELETE ON hizmetler
FOR EACH ROW
EXECUTE FUNCTION hizmetler_trigger_function();
