-- Для инициализации
INSERT INTO merch_requests(id, employee_id, merch_type_id, merch_status_id, issue_date)
VALUES (1, 1, 10, 1, null);

INSERT INTO merch_types(id, name)
VALUES (10, 'WelcomePack'), (20, 'ConferenceListenerPack');

INSERT INTO merch_statuses(id, name)
VALUES (0, 'Draft'), (1, 'Created'), (2, 'InWork'), (3, 'Done');

INSERT INTO items(id, name, merch_type_id)
VALUES (1, 'Pen', 10);