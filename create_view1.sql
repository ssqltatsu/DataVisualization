DROP VIEW female_bday_gacha_num_per_all_gacha_num;
DROP VIEW female_bday_gachas_num;
DROP VIEW user_gachas_num;

CREATE VIEW female_bday_gachas_num
AS
select f.birthday as f_bday, g.id as g_id, count(f.id) as num
FROM users f, gachas g, gacha_log gl
WHERE f.sex = '女' AND f.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1, 2
ORDER BY 1, 2;

CREATE VIEW user_gachas_num
AS
select u.birthday as u_bday, g.id as g_id, count(u.id) as num
FROM users u, gachas g, gacha_log gl
WHERE u.id = gl.u_id AND gl.gacha_id = g.id
GROUP BY 1, 2
ORDER BY 1, 2;

CREATE VIEW female_bday_gacha_num_per_all_gacha_num
AS
select f.f_bday as birthdat, f.g_id as g_id, 100*CAST(f.num as float)/CAST(u.num as float) as ratio
FROM female_bday_gachas_num f, user_gachas_num u
WHERE f.g_id = u.g_id AND f.f_bday = u.u_bday
ORDER BY 1, 2;