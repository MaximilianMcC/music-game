# music-game
rhythm game music thingy piano tiles 2014


# How make a song
To make a song then make a `.song` file inside of a directory with whatever name you want. The first section should contain a name, artist, mapper, difficult *(from 1 - 5, with 5 being hardest)*. A `#` is a comment btw. The duration part says how many **seconds** is waited before the next row is played. The cover image is always at `./cover.png` and the music/song is always at `./song.mp3`.
```
name: Song name here
artist: jeff
mapper: Bob

difficulty: 3
duration: 0.5
```
To make the actual song then you use the rows and columns of the file to define the time and lane for the song to be played in. Each column is a lane (0-4 (x axis (left/right))) and each row (0-whatever (y axis (up/down))) is the time that the note is played. if its a normal note then use a `#` character, if its a overdrive note then use a `@` character, and if its a holding note then use a `$` character. And if its noting then its a `.` character. This is what something could look like idk: (btw it starts from the bottom)
```
music:
....
....
....
#...
.#..
..#.
....
....
....
..$.
..$.
..$.
..$.
..$.
....
....
....
....
@..@
@..@
@..@
.@@.
.@@.
.@@.
@..@
@..@
@..@
....
....
....
```Everything gotta be this exact way (spaces and whatnot) until I clutch up and don't make a lazy parser (index based🤪🤪)

---
# 🤺🤺🤺