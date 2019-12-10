DROP VIEW female_bday_gacha_num_per_all_gacha_num;
DROP VIEW female_bday_gachas_num;
DROP VIEW user_gachas_num;
DROP VIEW female_num;
DROP VIEW user_num;
DROP VIEW female;
DROP VIEW content_num;
DROP VIEW age;

CREATE VIEW female_bday_gachas_num
AS
select date_part('year', f.birthday) as f_bday, g.id as g_id, count(f.id) as num
FROM users f, gachas g, gacha_log gl
WHERE f.sex = '女' AND f.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1, 2
ORDER BY 1, 2;

CREATE VIEW user_gachas_num
AS
select date_part('year', u.birthday) as u_bday, g.id as g_id, count(u.id) as num
FROM users u, gachas g, gacha_log gl
WHERE u.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1, 2
ORDER BY 1, 2;

CREATE VIEW female_bday_gacha_num_per_all_gacha_num
AS
select f.f_bday as birthday, f.g_id as g_id, FLOOR(100*CAST(f.num as float)/CAST(u.num as float)) as ratio
FROM female_bday_gachas_num f, user_gachas_num u
WHERE f.g_id = u.g_id AND f.f_bday = u.u_bday
ORDER BY 1, 2;


CREATE VIEW female
AS
select  g.id as g_id, count(f.id) as num
FROM users f, gachas g, gacha_log gl
WHERE f.sex = '女' AND f.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1
ORDER BY 1;

CREATE VIEW user_num
AS
select g.id as g_id, count(u.id) as num
FROM users u, gachas g, gacha_log gl
WHERE u.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1
ORDER BY 1;

CREATE VIEW female_num
AS
select f.g_id, FLOOR(100*CAST(f.num as float)/CAST(u.num as float)) as ratio
FROM female f, user_num u
WHERE f.g_id = u.g_id
ORDER BY 1;

CREATE VIEW  content_num
AS
select g.id as g_id, count(c.id) as num
from gachas g , appearance ap, contents c
where ap.gacha_id=g.id and ap.cont_id=c.id 
group by 1
order by 1;

CREATE VIEW age
AS
select 2018-birthday as age, *
from female_bday_gacha_num_per_all_gacha_num;
