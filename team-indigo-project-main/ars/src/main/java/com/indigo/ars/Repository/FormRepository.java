package com.indigo.ars.Repository;

import com.indigo.ars.Entity.Building;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Entity.Form;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

@Repository
public interface FormRepository extends CrudRepository<Form, Integer>, JpaSpecificationExecutor<Form> {
//    Page<Form> findAll(Specification<Form> spec, Pageable pageable);

    List<Form> findAll(Specification<Form> spec);



//    @Query("SELECT f FROM Form f WHERE :#{#spec.isSatisfiedBy(f)} " +
//            "ORDER BY CASE f.status " +
//            "WHEN 'waiting' THEN 1 " +
//            "WHEN 'edited' THEN 2 " +
//            "WHEN 'complete' THEN 3 ELSE 4 END")
//    Page<Form> findAllOrderedByStatus(@Param("spec") Specification<Form> spec, Pageable pageable);

    @Query("SELECT f FROM Form f WHERE f.reporter.email = :email ORDER BY CASE f.status " +
            "WHEN 'waiting' THEN 1 " +
            "WHEN 'edited' THEN 2 " +
            "WHEN 'complete' THEN 3 ELSE 4 END")
    Page<Form> findAllByReporterId(Pageable pageable, @Param("email") String email);
    @Query("SELECT f FROM Form f ORDER BY f.datetime")
    List<Form> findAllStatistic();
    @Query("SELECT f " +
            "FROM Form f " +
            "WHERE f.datetime >= :start " +
            "ORDER BY f.datetime")
    List<Form> findStatisticByTime(@Param("start") LocalDateTime start);
    Iterable<Form> getFormByReporter(Employee reporter);
    Iterable<Form> getFormByIncidentLocation(Building incidentLocation);
}
