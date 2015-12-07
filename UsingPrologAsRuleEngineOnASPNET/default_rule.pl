can_marrige(M) :- 
    spec(M, annual_income(I), height(H), class_curve(_), wealthy_parent(_)),
    I >= 1000,
    H >= 180.

can_marrige(M) :- 
    spec(M, annual_income(I), height(_), class_curve(S), wealthy_parent(_)),
    I >= 1000,
    S >= 65.

can_marrige(M) :- 
    spec(M, annual_income(_), height(H), class_curve(_), wealthy_parent(yes)),
    H >= 180.

can_marrige(M) :- 
    spec(M, annual_income(_), height(_), class_curve(S), wealthy_parent(yes)),
    S >= 65.
