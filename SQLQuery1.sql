use BDPasaje


SELECT Bus.IIDBUS, Bus.PLACA
FROM Bus
INNER JOIN Sucursal ON Bus.IIDBUS=Sucursal.IIDSUCURSAL
where bus.BHABILITADO = 1


select *
from Cliente
