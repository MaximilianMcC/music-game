# music-game
rhythm game music thingy piano tiles 2014

> [!WARNING]
> If you move the window when in a song the audio will go out of sync (raylib issue) 🤬🤬🤬

> [!WARNING]
> Notes are 'physically' dropped down, instead of being dependant of the time so it may be a little inaccurate. will fix in a v2 trust!!

# Plans and whatnot
Nothing here confirmed btw
- [ ] leaderboard for songs
- [ ] Online song downloader/browser so you don't have to manually import songs
- [ ] Fancy ui for a song/map editor
- [ ] More advanced note types
- [ ] Score can be added to notes. So if a note was in a very hard part of a song it could be worth more score

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
```
Everything gotta be this exact way (spaces and whatnot) until I clutch up and don't make a lazy parser (index based🤪🤪)

## New format
all the top stuff the same i think but then for the actual music its like this:
```song
<time (in milliseconds)>:<note type (same character as last time)><lane number (1-4)>
```
So this is something where it just goes up every second with a normal note
```song
music:
1000:#1
2000:#2
3000:#3
4000:#4
```
this one more difficult to write, but easier to parse !!

## new new format
erhmm so i'm changing back to old one again!! (previous too complicated to write (bad developer experiecen (not very good (valve please fix)))) so stuff looking like the below stuff. It starts from the bottom of the file, and each row/line is played every beat. In future update might add more flexibility like 3 times a beat or something but this is working for now trust
```
name: 60bpm debug
artist: kid off youtube
mapper: david semicolon (inventer of debugging)

difficulty: 1
bpm: 60

music:
...#
..#.
.#..
#...
```


---
# 🤺🤺🤺