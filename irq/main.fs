
include ex/fold.fs
include ex/svd.fs

: bitmask ( accum u -- n )
	bit or ;

: gpio-init ( -- )
	omode-pp pc13 io-mode!				\ set mode to output, push-pull
	pc13 ios! ;								\ turn led off

: tim-tick ( -- )
	%1 TIM1_SR hbic!						\ clear UIF
	\ ." HELLO" cr cr ;
	pc13 iox! ;

: rcc-init ( -- )
	$FFFF RCC_APB2ENR cbic!			\ reset peripheral clock
	0 4 11 ['] bitmask fold			\ set AFIOEN IOPCEN TIM1EN
	RCC_APB2ENR hbis!	 ;					\ config peripheral clock

: tim-init ( -- )	
	swap TIM1_PSC h!						\ set prescaler
	TIM1_ARR h!								\ set period
	0 bit TIM1_DIER h! ;				\ set UIE

: tim-start ( -- )
	0 bit TIM1_CR1 hbis! ;				\ set CEN

: irq-init ( -- )
	['] tim-tick irq-tim1up !
	%1 #25 lshift
	NVIC_ISER0 bis! ;						\ set TIM1_UP see p.197 RM

: main
	72MHz 1000 systick-hz
	rcc-init
	gpio-init
	7200 1- 10000 tim-init
	irq-init
	
	tim-start ;

main