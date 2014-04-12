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

CREATE TABLE equipment(name TEXT NOT NULL UNIQUE,
type TEXT CHECK(type IN ('HEAD', 'HAND', 'CHEST', 'LEG', 'FEET', 'ACCESSORY', 'WEAPON')),
lvl INTEGER CHECK(lvl>0),
str INTEGER CHECK(str>=0),
frt INTEGER CHECK(frt>=0),
dex INTEGER CHECK(dex>=0),
int INTEGER CHECK(int>=0));
INSERT INTO "equipment" VALUES('Burlap Sack', 'HEAD', 1, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Cardboard Box', 'CHEST', 1, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Twig','WEAPON', 1, 1, 1, NULL, NULL);
INSERT INTO "equipment" VALUES('Wok', 'WEAPON', NULL, 3, 5, NULL, NULL);
INSERT INTO "equipment" VALUES('Staff', 'WEAPON', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Skillet', 'WEAPON', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Dagger', 'WEAPON', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Shortsword', 'WEAPON', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "equipment" VALUES('Rapier', 'WEAPON', NULL, NULL, NULL, NULL, NULL);
 
CREATE TABLE enemies(name TEXT NOT NULL UNIQUE,
type TEXT NOT NULL CHECK(type IN ('MOB', 'MIDBOSS', 'BOSS')),
lvl INTEGER CHECK(lvl>0),
hp  INTEGER CHECK(hp>0),
str INTEGER CHECK(str>0),
frt INTEGER CHECK(frt>0),
dex INTEGER CHECK(dex>0),
int INTEGER CHECK(int>0),
aov INTEGER CHECK(aov>0),
expYield INTEGER CHECK(expYield>=0));
INSERT INTO "enemies" VALUES('Rat', 'MOB', 1, 5, 1, 1, 1, NULL, 1, 5);
INSERT INTO "enemies" VALUES('Stray Chicken', 'MOB', 1, 5, 2, 1, 2, NULL, 1, 5);
INSERT INTO "enemies" VALUES('Gnome', 'MOB', 2, NULL, NULL, NULL, NULL, NULL, 10, 10);
INSERT INTO "enemies" VALUES('Goat', 'MOB', 2, NULL, NULL, NULL, NULL, NULL, 10, 20);
INSERT INTO "enemies" VALUES('Wolf', 'MOB', 5, NULL, NULL, NULL, NULL, NULL, 30, 30);

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
INSERT INTO "scores" VALUES('ENEMY_HIT', 5);
INSERT INTO "scores" VALUES('ENEMY_KILL_MOB', 10);
INSERT INTO "scores" VALUES('ENEMY_KILL_MIDBOSS', 20);
INSERT INTO "scores" VALUES('ENEMY_KILL_BOSS', 50);
INSERT INTO "scores" VALUES('PC_LEVEL_UP', 30);
INSERT INTO "scores" VALUES('TIME_ELAPSE', 1);


COMMIT;
