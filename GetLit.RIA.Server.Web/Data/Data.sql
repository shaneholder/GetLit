set identity_insert Libraries on
insert into Libraries (LibraryId, Name) Values (1, 'First Library')
insert into Libraries (LibraryId, Name) Values (2, 'Second Library')
set identity_insert Libraries off

set identity_insert Titles on
insert into Titles (TitleId, Name, NetflixTitleId, LibraryId) values (1, 'Heartbreak Ridge', 'HR', 1)
insert into Titles (TitleId, Name, NetflixTitleId, LibraryId) values (2, 'Ghost Busters', 'HR', 1)
insert into Titles (TitleId, Name, NetflixTitleId, LibraryId) values (3, 'Pulp Fiction', 'HR', 2)
insert into Titles (TitleId, Name, NetflixTitleId, LibraryId) values (4, 'Raiders Of The Lost Ark', 'HR', 2)
set identity_insert Titles off
