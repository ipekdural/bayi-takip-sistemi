----------------get_customer_count-----------
DECLARE
    customer_count INTEGER;
BEGIN
    SELECT COUNT(*) INTO customer_count FROM public.Musteri;
    RETURN customer_count;
END;







---------------hesaplatoplamciro------------------

DECLARE
    total_gelir DECIMAL(10, 2);
    total_gider DECIMAL(10, 2);
    total_ciro DECIMAL(10, 2);
BEGIN
    -- Gelir tablosundaki toplam geliri hesapla
    SELECT COALESCE(SUM(toplam_gelir), 0) INTO total_gelir FROM public.Gelir;

    -- Gider tablosundaki toplam gideri hesapla
    SELECT COALESCE(SUM(toplam_gider), 0) INTO total_gider FROM public.Gider;

    -- Toplam ciroyu hesapla (gelirler - giderler)
    total_ciro := total_gelir - total_gider;

    -- Sonucu döndür
    RETURN total_ciro;
END;



-----------------usd_cevir-------------------------

BEGIN
    UPDATE public."hizmetler" SET "fiyat" = "fiyat" / 30;
END;







-----------------try_cevir------------------------

BEGIN
    UPDATE public."hizmetler" SET "fiyat" = "fiyat" * 30;
END;




