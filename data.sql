PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE weapons(name, valMin, valMax);
INSERT INTO "weapons" VALUES('Twig',1,5);
CREATE TABLE armor(name, type, valMin, valMax);
COMMIT;
