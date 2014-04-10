PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;

CREATE TABLE classes(name_class TEXT NOT NULL UNIQUE,
name_character_default_m TEXT NOT NULL UNIQUE,
name_character_default_f TEXT NOT NULL UNIQUE,
affin_str REAL NOT NULL,
affin_frt REAL NOT NULL,
affin_dex REAL NOT NULL);
INSERT INTO "classes" VALUES('Warrior',
'Duke Stabbington', 'Ella Stabbington',
0.5, 0.25, 0.25);
INSERT INTO "classes" VALUES('Rogue',
'Rynn Flider', 'Wynona Flider',
0.25, 0.5, 0.5);
INSERT INTO "classes" VALUES('Defender',
'Brick Head', 'Brienne Head',
0.25, 0.25, 0.5);
INSERT INTO "classes" VALUES('Peasant',
'Dwight Nobody', 'Gertrude Nobody',
0.34, 0.33, 0.33);

CREATE TABLE weapons(name TEXT NOT NULL UNIQUE,
valMin INTEGER CHECK(valMin>=0),
valMax INTEGER CHECK(valMax>=0));
INSERT INTO "weapons" VALUES('Twig',1,1);
INSERT INTO "weapons" VALUES('Wok',3,5);
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
str INTEGER CHECK(str>0),
frt INTEGER CHECK(frt>0),
dex INTEGER CHECK(dex>0),
expYield INTEGER CHECK(expYield>=0));
INSERT INTO "mobs" VALUES('Rat', 1, 5, 1, 1, 1, 5);
INSERT INTO "mobs" VALUES('Stray Chicken', 1, 5, 2, 1, 2, 5);
INSERT INTO "mobs" VALUES('Gnome', 2, NULL, NULL, NULL, NULL, 10);
INSERT INTO "mobs" VALUES('Goat', 2, NULL, NULL, NULL, NULL, 20);
INSERT INTO "mobs" VALUES('Wolf', 5, NULL, NULL, NULL, NULL, 30);

CREATE TABLE scores(event_name TEXT NOT NULL UNIQUE,
score_val INTEGER CHECK(score_val>=0));
INSERT INTO "scores" VALUES('CONTAINER_BREAK', 10);
INSERT INTO "scores" VALUES('ITEM_COLLECT_HEALER', 5);
INSERT INTO "scores" VALUES('ITEM_COLLECT_BUFF', 5);
INSERT INTO "scores" VALUES('ITEM_COLLECT_EQUIPMENT', 10);
INSERT INTO "scores" VALUES('ITEM_USE_HEALER_HP', 5);
INSERT INTO "scores" VALUES('ITEM_USE_HEALER_MP', 5);
INSERT INTO "scores" VALUES('ITEM_USE_HEALER_FOOD', 10);
INSERT INTO "scores" VALUES('ITEM_USE_BUFF', 5);
INSERT INTO "scores" VALUES('ENEMY_KILL_MOB', 5);
INSERT INTO "scores" VALUES('ENEMY_KILL_MIDBOSS', 20);
INSERT INTO "scores" VALUES('ENEMY_KILL_BOSS', 50);
INSERT INTO "scores" VALUES('PC_LEVEL_UP', 30);


COMMIT;
