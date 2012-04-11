#A palindromic number reads the same both ways.
#The largest palindrome made from the product of two 2-digit numbers is 9009 = 91*99.

#Find the largest palindrome made from the product of two 3-digit numbers.

#If the palindrome is the product of two 3 digit numbers,
#It's between 10^4 and 10^6 which gives us approximately a million numbers to test.
#Except not really because if we think of the palindrome as a reflected string
#with only 10 possible characters [0,1,..,9], the six digit string _ _ _ _ _ _
#can only be palindromic for 1000 combination of the numbers because the first
#number of the string defines the last number, the second number defines the second to last
#and so on. For the 6 digit string, the first number has 10 possible value (and it
#defines the last number as well). The second has 10 possible values and the third has 10
#possible values. When we get to the third, we're at the 'middle' of the string and we can stop
#There are only 1000 possible palindromes (10*10*10), very easy for the computer to handle.
#The case of 5 digit palindromes curiously also only has 1000 combinations :/

#lol all of ^^^ was irrelevant, just solved this by exhaustion


palList = []

#checks to see if a number is palindrome
def isPalindrome(n):
    number = str(n)
    size = len(number)
    for digit in xrange(0,size/2):
        if number[digit] != number[(size-1)-digit]:
            return False
    return True

#checks every duplet of three digit numbers
for out in xrange(999,100,-1):
    for ins in xrange(999,100,-1):
        if isPalindrome(out*ins) == True:
            palList.append(out*ins)


palList.sort()
print palList[len(palList)-1]

