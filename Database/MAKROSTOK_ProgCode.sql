USE MAKROSTOK
GO
---�R�N STOK EKLEME
CREATE PROCEDURE STOK.pURUNSTOK_EKLEME (@urunkodu AS NVARCHAR(10), @urunad� AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
INSERT INTO STOK.URUNSTOK(UrunKodu, UrunAd�, UrunBoyutu) VALUES (@urunkodu, @urunad�, @urunboyutu)
END
GO
---�RET�M EKLEME
CREATE PROCEDURE STOK.pURETIM_EKLEME (@uretimad� AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5))
AS
BEGIN
INSERT INTO STOK.URETIM(UretimAd�, UretimBoyutu) VALUES (@uretimad�, @uretimboyutu)
END
GO
---�RET�M STOK EKLEME
CREATE PROCEDURE STOK.pURETIMSTOK_EKLEME (@uretimstokad� AS NVARCHAR(50))
AS
BEGIN
INSERT INTO STOK.URETIMSTOK(UretStokAd�) VALUES (@uretimstokad�)
END
GO
---�R�N KUTULAMA
CREATE PROCEDURE STOK.pURUN_KUTULAMA (@urunkodu AS NVARCHAR(10), @urunad� AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5), @uretimad� AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5), @kutu AS BIT)
AS
BEGIN
INSERT INTO STOK.KUTULAMA VALUES ((SELECT UrunID FROM STOK.URUNSTOK WHERE UrunKodu = @urunkodu OR (UrunAd� = @urunad� AND UrunBoyutu = @urunboyutu)), (SELECT UretimID FROM STOK.URETIM WHERE UretimAd� = @uretimad� AND UretimBoyutu = @uretimboyutu), @kutu)
END
GO
---�RET�M ��LEM�
CREATE PROCEDURE STOK.pURETIM_ISLEMI (@uretimad� AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5), @uretimstokad� AS NVARCHAR(50), @punto AS BIT, @kapla AS BIT, @lastik AS BIT)
AS
BEGIN
INSERT INTO STOK.ISLEM VALUES ((SELECT UretStokID FROM STOK.URETIMSTOK WHERE UretStokAd� = @uretimstokad�), (SELECT UretimID FROM STOK.URETIM WHERE UretimAd� = @uretimad� AND UretimBoyutu = @uretimboyutu), @punto, @kapla, @lastik)
END
GO
---KUTULANMI� �R�N ADED�
CREATE PROCEDURE STOK.pKUTULANMIS_URUN (@urunkodu AS NVARCHAR(10), @urunad� AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
SELECT COUNT(*) AS N'Kutulanm�� �r�n Adedi'
FROM STOK.URUNSTOK
INNER JOIN STOK.KUTULAMA ON UrunID = UrunnID
WHERE UrunKodu = @urunkodu OR (UrunAd� = @urunad� AND UrunBoyutu = @urunboyutu)
END
GO
---PUNTOLANMI� MAL ADED�
CREATE PROCEDURE STOK.pPUNTO_MAL (@uretimstokad� AS NVARCHAR(50), @punto AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Puntolanm�� Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAd� = @uretimstokad� AND MalPuntoland� = @punto
END
GO
---KAPLANMI� MAL ADED�
CREATE PROCEDURE STOK.pKAPLA_MAL (@uretimstokad� AS NVARCHAR(50), @kapla AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Kaplanm�� Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAd� = @uretimstokad� AND MalKapland� = @kapla
END
GO
---LAST�KLENM�� MAL ADED�
CREATE PROCEDURE STOK.pLASTIK_MAL (@uretimstokad� AS NVARCHAR(50), @lastik AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Lastiklenmi� Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAd� = @uretimstokad� AND MalLastiklendi = @lastik
END
GO
---�R�N� STOKTAN �IKARMA
CREATE PROCEDURE STOK.pURUNSTOK_CIKAR (@urunkodu AS NVARCHAR(10), @urunad� AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
DELETE FROM STOK.URUNSTOK WHERE UrunKodu = @urunkodu OR (UrunAd� = @urunad� AND UrunBoyutu = @urunboyutu)
END
GO
---�RET�M� STOKTAN �IKARMA
CREATE PROCEDURE STOK.pURETIMI_CIKAR (@uretimad� AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5))
AS
BEGIN
DELETE FROM STOK.URETIM WHERE UretimAd� = @uretimad� AND UretimBoyutu = @uretimboyutu
END
GO
---ARAMAL_�IKARMA
CREATE PROCEDURE STOK.pURETIMSTOK_CIKAR (@uretimstokad� AS NVARCHAR(50))
AS
BEGIN
DELETE FROM STOK.URETIMSTOK WHERE UretStokAd� = @uretimstokad�
END
GO