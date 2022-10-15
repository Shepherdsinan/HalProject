SELECT (CASE WHEN STY_KASA_MIKTAR.GIRIS_CIKIS = 0 THEN 'G�R��' ELSE '�IKI�' END) AS [KASA DURUM], STY_KASA_MIKTAR.TARIH, STY_KASA_MIKTAR.CARI_KOD, ISNULL(STY_CARI.ADI, N'') AS [CARI ADI], 
                  STY_KASA_MIKTAR.DEPO_NO, STY_DEPO.DEPO_TANIM, STY_KASA_MIKTAR.KASA_NO, STY_KASA.TANIM, STY_KASA_MIKTAR.MIKTAR
FROM     STY_KASA_MIKTAR INNER JOIN
                  STY_KASA ON STY_KASA_MIKTAR.KASA_NO = STY_KASA.NO LEFT OUTER JOIN
                  STY_DEPO ON STY_KASA_MIKTAR.DEPO_NO = STY_DEPO.DEPO_NO LEFT OUTER JOIN
                  STY_CARI ON STY_KASA_MIKTAR.CARI_KOD = STY_CARI.KODU
WHERE  (STY_KASA.IADE = 1)
ORDER BY STY_KASA_MIKTAR.TARIH