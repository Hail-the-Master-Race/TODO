PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;

CREATE TABLE weapons(name TEXT NOT NULL UNIQUE,
valMin INTEGER CHECK(valMin>=0),
valMax INTEGER CHECK(valMax>=0));
INSERT INTO "weapons" VALUES('Twig',NULL,NULL);
INSERT INTO "weapons" VALUES('Wok',NULL,NULL);
INSERT INTO "weapons" VALUES('Staff',NULL,NULL);
INSERT INTO "weapons" VALUES('Skillet',NULL,NULL);
INSERT INTO "weapons" VALUES('Dagger',NULL,NULL);
INSERT INTO "weapons" VALUES('Shortsword',NULL,NULL);
INSERT INTO "weapons" VALUES('Rapier',NULL,NULL);

CREATE TABLE armor(name TEXT NOT NULL UNIQUE,
type TEXT,
valMin INTEGER CHECK(valMin>=0), valMax INTEGER CHECK(valMax>=0));

CREATE TABLE mobs(name TEXT NOT NULL UNIQUE,
lvl INTEGER CHECK(lvl>0),
hp  INTEGER CHECK(hp>0),
str INTEGER CHECK(str>=0),
frt INTEGER CHECK(frt>=0),
dex INTEGER CHECK(dex>=0),
expYield INTEGER CHECK(expYield>=0));
INSERT INTO "mobs" VALUES('Rat', 1, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "mobs" VALUES('Stray Chicken', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "mobs" VALUES('Gnome', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "mobs" VALUES('Wolf', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "mobs" VALUES('Goat', NULL, NULL, NULL, NULL, NULL, NULL);

CREATE TABLE scores(event_name TEXT NOT NULL UNIQUE,
score_val INTEGER CHECK(score_val>=0));
INSERT INTO "scores" VALUES('CONTAINER_BREAK', 10);
INSERT INTO "scores" VALUES('ITEM_COLLECT_HEALER', 5);
INSERT INTO "scores" VALUES('ITEM_COLLECT_BUFF', 5);
INSERT INTO "scores" VALUES('ITEM_COLLECT_EQUIPMENT', 10);
INSERT INTO "scores" VALUES('ENEMY_KILL_MOB', 5);
INSERT INTO "scores" VALUES('ENEMY_KILL_MIDBOSS', 20);
INSERT INTO "scores" VALUES('ENEMY_KILL_BOSS', 50);
INSERT INTO "scores" VALUES('PC_LEVEL_UP', 30);


COMMIT;
