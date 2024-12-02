package dishdive.configuration.security;

import dishdive.configuration.security.auth.AuthenticationRequestFilter;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.method.configuration.EnableMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configurers.AbstractHttpConfigurer;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.web.AuthenticationEntryPoint;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@EnableWebSecurity
@EnableMethodSecurity(jsr250Enabled = true)
@Configuration
public class WebSecurityConfig {
    private static final String[] SWAGGER_UI_RESOURCES = {
            "/swagger-resources/**",
            "/swagger-ui.html",
            "/swagger-ui/**"
    };
    private final String chefChefIdPath = "/chef/{chefId}";
    private final String ADMIN = "ADMIN";
    private final String SUPER_CHEF = "SUPER_CHEF";
    private final String CHEF = "CHEF";

    @Bean
    public SecurityFilterChain filterChain(HttpSecurity httpSecurity, AuthenticationEntryPoint authenticationEntryPoint, AuthenticationRequestFilter authenticationRequestFilter) throws Exception {
        httpSecurity
                .csrf(AbstractHttpConfigurer::disable)
                .formLogin(AbstractHttpConfigurer::disable)
                .sessionManagement(configurer ->
                        configurer.sessionCreationPolicy(SessionCreationPolicy.STATELESS))
                .authorizeHttpRequests(registry ->
                        registry.requestMatchers(HttpMethod.OPTIONS, "/**").permitAll()
                                .requestMatchers(HttpMethod.GET,"/chef/{chefId}/recipes", "/chef/{chefUsername}", "/chef/getOne/{chefId}", "/rating/{recipeId}", "/recipe", "/recipe/{recipeId}").permitAll()
                                .requestMatchers(HttpMethod.GET,"/chef").hasRole(ADMIN)

                                .requestMatchers(HttpMethod.POST,"/chef/login", "/chef/create").permitAll()
                                .requestMatchers(HttpMethod.POST,"/rating/create", "/rating/delete/{ratingId}", "/recipe/create").hasAnyRole(CHEF, SUPER_CHEF, ADMIN)
                                .requestMatchers(HttpMethod.POST,"/recipe/create").hasAnyRole(CHEF, SUPER_CHEF)

                                .requestMatchers(HttpMethod.PUT, "/chef/update-password/{chefId}", "/chef/{chefId}", "/recipe/edit/{recipeId}").hasAnyRole(CHEF, SUPER_CHEF, ADMIN)

                                .requestMatchers(HttpMethod.DELETE, "/chef/{chefId}", "/recipe/delete/{recipeId}").hasAnyRole(CHEF, SUPER_CHEF, ADMIN)
                                .requestMatchers("/ws").permitAll()
                                .requestMatchers(SWAGGER_UI_RESOURCES).permitAll()
                                .anyRequest().authenticated()
                )
                .exceptionHandling(configure -> configure.authenticationEntryPoint(authenticationEntryPoint))
                .addFilterBefore(authenticationRequestFilter, UsernamePasswordAuthenticationFilter.class);
        return httpSecurity.build();
    }

    @Bean
    public WebMvcConfigurer corsConfigurer() {
        return new WebMvcConfigurer() {
            @Override
            public void addCorsMappings(CorsRegistry registry) {
                registry.addMapping("/**")
                        .allowedOrigins("http://localhost:5173")
                        .allowedMethods("GET", "POST", "PUT", "DELETE")
                        .allowedHeaders("Authorization", "Content-Type")
                        .allowCredentials(true)
                        .maxAge(3600);
            }
        };
    }
}
