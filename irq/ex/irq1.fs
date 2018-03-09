
$E000E100 							constant NVIC
NVIC $0 +							constant NVIC_ISER0					\ see p.128 PM

$40012C00							constant TIM1
TIM1 $0 +  							constant TIM1_CR1
TIM1 $8 +  							constant TIM1_SMCR
TIM1 $C +  							constant TIM1_DIER
TIM1 $10 +							constant TIM1_SR
TIM1 $24 +  						constant TIM1_CNT
TIM1 $28 +  						constant TIM1_PSC
TIM1 $2C +  						constant TIM1_ARR

: gpio-init ( -- )
	omode-pp pc13 io-mode!				\ set mode to output, push-pull
	pc13 ios! ;								\ turn led off

: tim-tick ( -- )
	%1 TIM1_SR hbic!						\ clear UIF
	pc13 iox! ;								\ toggle led

: psc+arr ( psc arr -- c )			\ prescaler and period in a single cell
	swap 1- 16 lshift or ;

: timer-start ( -- )
	%1 TIM1_CR1 hbis! ;					\ set CEN

: irq-init ( -- )
	['] tim-tick irq-tim1up !
	%1 #25 lshift
	NVIC_ISER0 bis! ;						\ set TIM1_UP see p.197 RM

72MHz
1000 systick-hz

gpio-init
7200 10000 psc+arr						\ set prescaler and period 
1 timer-init								\ config TIM1
%1 TIM1_DIER hbis!						\ set UIE
irq-init										\ TIM1_UP interrupt

timer-start

