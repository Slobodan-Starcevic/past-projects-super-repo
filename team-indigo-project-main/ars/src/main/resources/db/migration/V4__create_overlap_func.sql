CREATE OR REPLACE FUNCTION array_overlap_custom(varchar_array character varying[], text_array text[])
RETURNS boolean AS $$
DECLARE
element text;
BEGIN
    FOREACH element IN ARRAY text_array
    LOOP
        IF element = ANY(varchar_array) THEN
            RETURN true;
END IF;
END LOOP;
RETURN false;
END;
$$ LANGUAGE plpgsql;
