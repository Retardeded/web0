public interface State 
{
    void setChangeability(StateHandler context, bool changeability);
    void setSymmetricity(StateHandler context, bool symmetricity);
    void strechCorrespondingPart(LenghtenSingleClothSymmetrically context, float scaleFactor);
}
