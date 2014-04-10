PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;

CREATE TABLE achievements(name TEXT NOT NULL UNIQUE,
description TEXT NOT NULL UNIQUE,
img_path TEXT NOT NULL UNIQUE);
-- TODO: add a "condition" column

CREATE TABLE classes(name_class TEXT NOT NULL UNIQUE,
name_character_default_m TEXT NOT NULL UNIQUE,
name_character_default_f TEXT NOT NULL UNIQUE,
descriptor TEXT NOT NULL UNIQUE,
affin_str REAL NOT NULL,
affin_frt REAL NOT NULL,
affin_dex REAL NOT NULL,
affin_int REAL NOT NULL);
INSERT INTO "classes" VALUES('Warrior',
'Duke Stabbington', 'Ella Stabbington',
'IIIII HAAAAAVE THE POOOOWEEEEER.',
0.5, 0.25, 0.25, 0);
INSERT INTO "classes" VALUES('Rogue',
'Rynn Flider', 'Wynona Flider',
'Feel my smolder. No, seriously.',
0.25, 0.5, 0.5, 0);
INSERT INTO "classes" VALUES('Defender',
'Brick Head', 'Brienne Head',
'Does my shield make me look big? Good.',
0.25, 0.25, 0.5, 0);
INSERT INTO "classes" VALUES('Peasant',
'Dwight Nobody', 'Gertrude Nobody',
'Nobody loves me :(',
0.34, 0.33, 0.33, 0);

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
valMin INTEGER CHECK(valMin>=0),
valMax INTEGER CHECK(valMax>=0));

CREATE TABLE mobs(name TEXT NOT NULL UNIQUE,
lvl INTEGER CHECK(lvl>0),
hp  INTEGER CHECK(hp>0),
str INTEGER CHECK(str>0),
frt INTEGER CHECK(frt>0),
dex INTEGER CHECK(dex>0),
int INTEGER CHECK(int>0),
aov INTEGER CHECK(aov>0),
expYield INTEGER CHECK(expYield>=0));
INSERT INTO "mobs" VALUES('Rat', 1, 5, 1, 1, 1, NULL, 1, 5);
INSERT INTO "mobs" VALUES('Stray Chicken', 1, 5, 2, 1, 2, NULL, 1, 5);
INSERT INTO "mobs" VALUES('Gnome', 2, NULL, NULL, NULL, NULL, NULL, 10, 10);
INSERT INTO "mobs" VALUES('Goat', 2, NULL, NULL, NULL, NULL, NULL, 10, 20);
INSERT INTO "mobs" VALUES('Wolf', 5, NULL, NULL, NULL, NULL, NULL, 30, 30);

CREATE TABLE midbosses(name TEXT NOT NULL UNIQUE,
lvl INTEGER CHECK(lvl>0),
hp  INTEGER CHECK(hp>0),
str INTEGER CHECK(str>0),
frt INTEGER CHECK(frt>0),
dex INTEGER CHECK(dex>0),
int INTEGER CHECK(int>0),
aov INTEGER CHECK(aov>0),
expYield INTEGER CHECK(expYield>=0));

CREATE TABLE bosses(name TEXT NOT NULL UNIQUE,
lvl INTEGER CHECK(lvl>0),
hp  INTEGER CHECK(hp>0),
str INTEGER CHECK(str>0),
frt INTEGER CHECK(frt>0),
dex INTEGER CHECK(dex>0),
int INTEGER CHECK(int>0),
expYield INTEGER CHECK(expYield>=0));

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
