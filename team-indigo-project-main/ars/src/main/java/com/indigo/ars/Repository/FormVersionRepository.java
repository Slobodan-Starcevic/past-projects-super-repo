package com.indigo.ars.Repository;


import com.indigo.ars.Entity.FormVersion;
import jakarta.transaction.Transactional;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;



@Repository
public interface FormVersionRepository extends CrudRepository<FormVersion, Integer> {

    @Query("SELECT MAX(fv.version) FROM FormVersion fv WHERE fv.form.id = :formId")
    Integer getLastVersionNumber(@Param("formId") int formId);

    @Modifying
    @Transactional
    @Query("delete FROM FormVersion fv WHERE fv.form.id = :formId")
    void deleteFormsById(@Param("formId") int formId);

    @Query("SELECT fv FROM FormVersion fv WHERE fv.form.id = :formId and fv.version = :formVer")
    FormVersion getFormVersion(@Param("formId") int formId, @Param("formVer") int formVersion);
}
