-- Для инициализации
INSERT INTO merch_types(id, name)
VALUES (10, 'WelcomePack'), (20, 'ConferenceListenerPack'), (30, 'ConferenceSpeakerPack'), (40, 'ProbationPeriodEndingPack'), (50, 'VeteranPack');

INSERT INTO merch_request_statuses(id, name)
VALUES (0, 'Draft'), (1, 'Created'), (2, 'InWork'), (3, 'Done'), (4, 'Decline');

INSERT INTO merch_packes(merch_type_id, can_be_reissued, can_be_reissued_after_days)
VALUES (10, false, null), (20, true, 1),(30, true, 10),(40, false, null),(50, true, 365)

INSERT INTO skus(merch_pack_id, value)
VALUES (1, 10), (1, 11), (1, 12), (2, 20), (2, 21), (3, 30), (4, 40), (5, 50), (5, 51), (5, 52), (5, 53)

INSERT INTO merch_requests(request_status_id, employee_email, merch_pack_id, create_date, issue_date)
VALUES (1, 'test@test.ru', 1, CURRENT_DATE, null), (1, 'test2@test.ru', 2, CURRENT_DATE, null)



SELECT mr.id, mr.request_status_id, mr.employee_email, mr.merch_pack_id, mr.create_date, mr.issue_date,
		rs.id, rs.name,
		mp.id, mp.merch_type_id, mp.can_be_reissued, mp.can_be_reissued_after_days,
		mt.id, mt.name,
		sk.id, sk.value
FROM merch_requests mr
INNER JOIN merch_request_statuses rs ON rs.id = mr.request_status_id
INNER JOIN merch_packes mp ON mp.id = mr.merch_pack_id
INNER JOIN merch_types mt ON mt.id = mp.merch_type_id
INNER JOIN skus sk ON sk.merch_pack_id = mp.id
WHERE mr.employee_email = 'test@test.ru';