# TODO: Temple of Doom, Obviously #

## About `data.db` ##
To facilitate diff-ing, we have opted to version-control a text dump of
`data.db`, the main database file, rather than `data.db` itself.

To repopulate a `data.db` database file for deployment, run the following:
`echo ".read data.sql" | sqlite3 data.db`
