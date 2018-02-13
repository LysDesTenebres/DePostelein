package com.depostelein.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

@ComponentScan
@EnableAutoConfiguration
@EnableJpaRepositories
@SpringBootApplication
@EnableGlobalMethodSecurity(securedEnabled = true)
public class BackendDeposteleinApplication {

	public static void main(String[] args) {
		SpringApplication.run(BackendDeposteleinApplication.class, args);
	}
}
