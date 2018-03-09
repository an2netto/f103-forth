\ from svd2forth-v2

$40021000 							constant RCC
RCC $18 +  							constant RCC_APB2ENR

$E000E100 							constant NVIC
NVIC $0 +							constant NVIC_ISER0					\ see p.128 PM

$40012C00							constant TIM1
TIM1 $0 +  							constant TIM1_CR1
TIM1 $4 +  							constant TIM1_CR2
TIM1 $8 +  							constant TIM1_SMCR
TIM1 $C +  							constant TIM1_DIER
TIM1 $10 +							constant TIM1_SR
TIM1 $24 +  						constant TIM1_CNT
TIM1 $28 +  						constant TIM1_PSC
TIM1 $2C +  						constant TIM1_ARR

: b32loop. ( u -- ) \ print 1 bit groups
0  <#
31 0 DO 
# 32 HOLD LOOP
# #>
TYPE ; 

: 1b. ( u -- ) cr 
." 3|3|2|2|2|2|2|2|2|2|2|2|1|1|1|1|1|1|1|1|1|1" cr
." 1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0 " cr
@ binary b32loop. decimal cr ;


: b8loop. ( u -- )
0 <#
7 0 DO
# # # #
32 HOLD
LOOP
# # # # 
#>
TYPE ;

: 4b. ( u -- ) cr \ Print 4 bit groups
."  07   06   05   04   03   02   01   00  " cr
@ binary b8loop. cr ;


: b16loop. ( u -- ) 0
<#
15 0 DO
# #
32 HOLD
LOOP
# #
#>
TYPE ;

: 2b. ( u -- ) cr \ Print 2 bit groups
." 15|14|13|12|11|10|09|08|07|06|05|04|03|02|01|00 " cr
@ binary b16loop. cr
;

: RCC_APB2ENR. ." RCC_APB2ENR (read-write) $" RCC_APB2ENR @ hex. RCC_APB2ENR RCC_APB2ENR 1b. ;

: NVIC_ISER0. ." NVIC_ISER0 (read-write) $" NVIC_ISER0 @ hex. NVIC_ISER0 NVIC_ISER0 1b. ;

: TIM1_CR1. ." TIM1_CR1 (read-write) $" TIM1_CR1 @ hex. TIM1_CR1 TIM1_CR1 1b. ;
: TIM1_CR2. ." TIM1_CR2 (read-write) $" TIM1_CR2 @ hex. TIM1_CR2 TIM1_CR2 1b. ;
: TIM1_SMCR. ." TIM1_SMCR (read-write) $" TIM1_SMCR @ hex. TIM1_SMCR TIM1_SMCR 1b. ;
: TIM1_DIER. ." TIM1_DIER (read-write) $" TIM1_DIER @ hex. TIM1_DIER TIM1_DIER 1b. ;
: TIM1_SR. ." TIM1_SR (read-write) $" TIM1_SR @ hex. TIM1_SR TIM1_SR 1b. ;
: TIM1_PSC. ." TIM1_PSC (read-write) $" TIM1_PSC @ hex. TIM1_PSC TIM1_PSC 1b. ;
: TIM1_ARR. ." TIM1_ARR (read-write) $" TIM1_ARR @ hex. TIM1_ARR TIM1_ARR 1b. ;
: TIM1_CNT. ." TIM1_CNT (read-write) $" TIM1_CNT @ hex. TIM1_CNT TIM1_CNT 1b. ;
