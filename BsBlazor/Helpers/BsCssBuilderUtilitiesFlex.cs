namespace BsBlazor;

public partial class BsCssBuilder
{
    // Flex Direction 
    public BsCssBuilder FlexRow => AddClass("flex-row");
    public BsCssBuilder FlexSmallRow => AddClass("flex-sm-row");
    public BsCssBuilder FlexMediumRow => AddClass("flex-md-row");
    public BsCssBuilder FlexLargeRow => AddClass("flex-lg-row");
    public BsCssBuilder FlexExtraLargeRow => AddClass("flex-xl-row");
    public BsCssBuilder FlexExtraExtraLargeRow => AddClass("flex-xxl-row");
    
    public BsCssBuilder FlexRowReverse => AddClass("flex-row-reverse");
    public BsCssBuilder FlexSmallRowReverse => AddClass("flex-sm-row-reverse");
    public BsCssBuilder FlexMediumRowReverse => AddClass("flex-md-row-reverse");
    public BsCssBuilder FlexLargeRowReverse => AddClass("flex-lg-row-reverse");
    public BsCssBuilder FlexExtraLargeRowReverse => AddClass("flex-xl-row-reverse");
    public BsCssBuilder FlexExtraExtraLargeRowReverse => AddClass("flex-xxl-row-reverse");
    
    public BsCssBuilder FlexColumn => AddClass("flex-column");
    public BsCssBuilder FlexSmallColumn => AddClass("flex-sm-column");
    public BsCssBuilder FlexMediumColumn => AddClass("flex-md-column");
    public BsCssBuilder FlexLargeColumn => AddClass("flex-lg-column");
    public BsCssBuilder FlexExtraLargeColumn => AddClass("flex-xl-column");
    public BsCssBuilder FlexExtraExtraLargeColumn => AddClass("flex-xxl-column");
    
    public BsCssBuilder FlexColumnReverse => AddClass("flex-column-reverse");
    public BsCssBuilder FlexSmallColumnReverse => AddClass("flex-sm-column-reverse");
    public BsCssBuilder FlexMediumColumnReverse => AddClass("flex-md-column-reverse");
    public BsCssBuilder FlexLargeColumnReverse => AddClass("flex-lg-column-reverse");
    public BsCssBuilder FlexExtraLargeColumnReverse => AddClass("flex-xl-column-reverse");
    public BsCssBuilder FlexExtraExtraLargeColumnReverse => AddClass("flex-xxl-column-reverse");
    
    // Justify content
    public BsCssBuilder JustifyContentStart => AddClass("justify-content-start");
    public BsCssBuilder JustifyContentSmallStart => AddClass("justify-content-sm-start");
    public BsCssBuilder JustifyContentMediumStart => AddClass("justify-content-md-start");
    public BsCssBuilder JustifyContentLargeStart => AddClass("justify-content-lg-start");
    public BsCssBuilder JustifyContentExtraLargeStart => AddClass("justify-content-xl-start");
    public BsCssBuilder JustifyContentExtraExtraLargeStart => AddClass("justify-content-xxl-start");
    
    public BsCssBuilder JustifyContentEnd => AddClass("justify-content-end");
    public BsCssBuilder JustifyContentSmallEnd => AddClass("justify-content-sm-end");
    public BsCssBuilder JustifyContentMediumEnd => AddClass("justify-content-md-end");
    public BsCssBuilder JustifyContentLargeEnd => AddClass("justify-content-lg-end");
    public BsCssBuilder JustifyContentExtraLargeEnd => AddClass("justify-content-xl-end");
    public BsCssBuilder JustifyContentExtraExtraLargeEnd => AddClass("justify-content-xxl-end");
    
    public BsCssBuilder JustifyContentCenter => AddClass("justify-content-center");
    public BsCssBuilder JustifyContentSmallCenter => AddClass("justify-content-sm-center");
    public BsCssBuilder JustifyContentMediumCenter => AddClass("justify-content-md-center");
    public BsCssBuilder JustifyContentLargeCenter => AddClass("justify-content-lg-center");
    public BsCssBuilder JustifyContentExtraLargeCenter => AddClass("justify-content-xl-center");
    public BsCssBuilder JustifyContentExtraExtraLargeCenter => AddClass("justify-content-xxl-center");
    
    public BsCssBuilder JustifyContentBetween => AddClass("justify-content-between");
    public BsCssBuilder JustifyContentSmallBetween => AddClass("justify-content-sm-between");
    public BsCssBuilder JustifyContentMediumBetween => AddClass("justify-content-md-between");
    public BsCssBuilder JustifyContentLargeBetween => AddClass("justify-content-lg-between");
    public BsCssBuilder JustifyContentExtraLargeBetween => AddClass("justify-content-xl-between");
    public BsCssBuilder JustifyContentExtraExtraLargeBetween => AddClass("justify-content-xxl-between");
    
    public BsCssBuilder JustifyContentAround => AddClass("justify-content-around");
    public BsCssBuilder JustifyContentSmallAround => AddClass("justify-content-sm-around");
    public BsCssBuilder JustifyContentMediumAround => AddClass("justify-content-md-around");
    public BsCssBuilder JustifyContentLargeAround => AddClass("justify-content-lg-around");
    public BsCssBuilder JustifyContentExtraLargeAround => AddClass("justify-content-xl-around");
    public BsCssBuilder JustifyContentExtraExtraLargeAround => AddClass("justify-content-xxl-around");
    
    public BsCssBuilder JustifyContentEvenly => AddClass("justify-content-evenly");
    public BsCssBuilder JustifyContentSmallEvenly => AddClass("justify-content-sm-evenly");
    public BsCssBuilder JustifyContentMediumEvenly => AddClass("justify-content-md-evenly");
    public BsCssBuilder JustifyContentLargeEvenly => AddClass("justify-content-lg-evenly");
    public BsCssBuilder JustifyContentExtraLargeEvenly => AddClass("justify-content-xl-evenly");
    public BsCssBuilder JustifyContentExtraExtraLargeEvenly => AddClass("justify-content-xxl-evenly");
    
    // Align items
    public BsCssBuilder AlignItemsStart => AddClass("align-items-start");
    public BsCssBuilder AlignItemsSmallStart => AddClass("align-items-sm-start");
    public BsCssBuilder AlignItemsMediumStart => AddClass("align-items-md-start");
    public BsCssBuilder AlignItemsLargeStart => AddClass("align-items-lg-start");
    public BsCssBuilder AlignItemsExtraLargeStart => AddClass("align-items-xl-start");
    public BsCssBuilder AlignItemsExtraExtraLargeStart => AddClass("align-items-xxl-start");
    
    public BsCssBuilder AlignItemsEnd => AddClass("align-items-end");
    public BsCssBuilder AlignItemsSmallEnd => AddClass("align-items-sm-end");
    public BsCssBuilder AlignItemsMediumEnd => AddClass("align-items-md-end");
    public BsCssBuilder AlignItemsLargeEnd => AddClass("align-items-lg-end");
    public BsCssBuilder AlignItemsExtraLargeEnd => AddClass("align-items-xl-end");
    public BsCssBuilder AlignItemsExtraExtraLargeEnd => AddClass("align-items-xxl-end");
    
    public BsCssBuilder AlignItemsCenter => AddClass("align-items-center");
    public BsCssBuilder AlignItemsSmallCenter => AddClass("align-items-sm-center");
    public BsCssBuilder AlignItemsMediumCenter => AddClass("align-items-md-center");
    public BsCssBuilder AlignItemsLargeCenter => AddClass("align-items-lg-center");
    public BsCssBuilder AlignItemsExtraLargeCenter => AddClass("align-items-xl-center");
    public BsCssBuilder AlignItemsExtraExtraLargeCenter => AddClass("align-items-xxl-center");
    
    public BsCssBuilder AlignItemsBaseline => AddClass("align-items-baseline");
    public BsCssBuilder AlignItemsSmallBaseline => AddClass("align-items-sm-baseline");
    public BsCssBuilder AlignItemsMediumBaseline => AddClass("align-items-md-baseline");
    public BsCssBuilder AlignItemsLargeBaseline => AddClass("align-items-lg-baseline");
    public BsCssBuilder AlignItemsExtraLargeBaseline => AddClass("align-items-xl-baseline");
    public BsCssBuilder AlignItemsExtraExtraLargeBaseline => AddClass("align-items-xxl-baseline");
    
    public BsCssBuilder AlignItemsStretch => AddClass("align-items-stretch");
    public BsCssBuilder AlignItemsSmallStretch => AddClass("align-items-sm-stretch");
    public BsCssBuilder AlignItemsMediumStretch => AddClass("align-items-md-stretch");
    public BsCssBuilder AlignItemsLargeStretch => AddClass("align-items-lg-stretch");
    public BsCssBuilder AlignItemsExtraLargeStretch => AddClass("align-items-xl-stretch");
    public BsCssBuilder AlignItemsExtraExtraLargeStretch => AddClass("align-items-xxl-stretch");
    
    // Align self
    public BsCssBuilder AlignSelfStart => AddClass("align-self-start");
    public BsCssBuilder AlignSelfSmallStart => AddClass("align-self-sm-start");
    public BsCssBuilder AlignSelfMediumStart => AddClass("align-self-md-start");
    public BsCssBuilder AlignSelfLargeStart => AddClass("align-self-lg-start");
    public BsCssBuilder AlignSelfExtraLargeStart => AddClass("align-self-xl-start");
    public BsCssBuilder AlignSelfExtraExtraLargeStart => AddClass("align-self-xxl-start");
    
    public BsCssBuilder AlignSelfEnd => AddClass("align-self-end");
    public BsCssBuilder AlignSelfSmallEnd => AddClass("align-self-sm-end");
    public BsCssBuilder AlignSelfMediumEnd => AddClass("align-self-md-end");
    public BsCssBuilder AlignSelfLargeEnd => AddClass("align-self-lg-end");
    public BsCssBuilder AlignSelfExtraLargeEnd => AddClass("align-self-xl-end");
    public BsCssBuilder AlignSelfExtraExtraLargeEnd => AddClass("align-self-xxl-end");
    
    public BsCssBuilder AlignSelfCenter => AddClass("align-self-center");
    public BsCssBuilder AlignSelfSmallCenter => AddClass("align-self-sm-center");
    public BsCssBuilder AlignSelfMediumCenter => AddClass("align-self-md-center");
    public BsCssBuilder AlignSelfLargeCenter => AddClass("align-self-lg-center");
    public BsCssBuilder AlignSelfExtraLargeCenter => AddClass("align-self-xl-center");
    public BsCssBuilder AlignSelfExtraExtraLargeCenter => AddClass("align-self-xxl-center");
    
    public BsCssBuilder AlignSelfBaseline => AddClass("align-self-baseline");
    public BsCssBuilder AlignSelfSmallBaseline => AddClass("align-self-sm-baseline");
    public BsCssBuilder AlignSelfMediumBaseline => AddClass("align-self-md-baseline");
    public BsCssBuilder AlignSelfLargeBaseline => AddClass("align-self-lg-baseline");
    public BsCssBuilder AlignSelfExtraLargeBaseline => AddClass("align-self-xl-baseline");
    public BsCssBuilder AlignSelfExtraExtraLargeBaseline => AddClass("align-self-xxl-baseline");
    
    public BsCssBuilder AlignSelfStretch => AddClass("align-self-stretch");
    public BsCssBuilder AlignSelfSmallStretch => AddClass("align-self-sm-stretch");
    public BsCssBuilder AlignSelfMediumStretch => AddClass("align-self-md-stretch");
    public BsCssBuilder AlignSelfLargeStretch => AddClass("align-self-lg-stretch");
    public BsCssBuilder AlignSelfExtraLargeStretch => AddClass("align-self-xl-stretch");
    public BsCssBuilder AlignSelfExtraExtraLargeStretch => AddClass("align-self-xxl-stretch");
    
    // Fill
    public BsCssBuilder FlexFill => AddClass("flex-fill");
    public BsCssBuilder FlexSmallFill => AddClass("flex-sm-fill");
    public BsCssBuilder FlexMediumFill => AddClass("flex-md-fill");
    public BsCssBuilder FlexLargeFill => AddClass("flex-lg-fill");
    public BsCssBuilder FlexExtraLargeFill => AddClass("flex-xl-fill");
    public BsCssBuilder FlexExtraExtraLargeFill => AddClass("flex-xxl-fill");
    
    // Grow and Shrink
    public BsCssBuilder FlexGrow0 => AddClass("flex-grow-0");
    public BsCssBuilder FlexGrow1 => AddClass("flex-grow-1");
    public BsCssBuilder FlexSmallGrow0 => AddClass("flex-sm-grow-0");
    public BsCssBuilder FlexSmallGrow1 => AddClass("flex-sm-grow-1");
    public BsCssBuilder FlexMediumGrow0 => AddClass("flex-md-grow-0");
    public BsCssBuilder FlexMediumGrow1 => AddClass("flex-md-grow-1");
    public BsCssBuilder FlexLargeGrow0 => AddClass("flex-lg-grow-0");
    public BsCssBuilder FlexLargeGrow1 => AddClass("flex-lg-grow-1");
    public BsCssBuilder FlexExtraLargeGrow0 => AddClass("flex-xl-grow-0");
    public BsCssBuilder FlexExtraLargeGrow1 => AddClass("flex-xl-grow-1");
    public BsCssBuilder FlexExtraExtraLargeGrow0 => AddClass("flex-xxl-grow-0");
    public BsCssBuilder FlexExtraExtraLargeGrow1 => AddClass("flex-xxl-grow-1");
    
    public BsCssBuilder FlexShrink0 => AddClass("flex-shrink-0");
    public BsCssBuilder FlexShrink1 => AddClass("flex-shrink-1");
    public BsCssBuilder FlexSmallShrink0 => AddClass("flex-sm-shrink-0");
    public BsCssBuilder FlexSmallShrink1 => AddClass("flex-sm-shrink-1");
    public BsCssBuilder FlexMediumShrink0 => AddClass("flex-md-shrink-0");
    public BsCssBuilder FlexMediumShrink1 => AddClass("flex-md-shrink-1");
    public BsCssBuilder FlexLargeShrink0 => AddClass("flex-lg-shrink-0");
    public BsCssBuilder FlexLargeShrink1 => AddClass("flex-lg-shrink-1");
    public BsCssBuilder FlexExtraLargeShrink0 => AddClass("flex-xl-shrink-0");
    public BsCssBuilder FlexExtraLargeShrink1 => AddClass("flex-xl-shrink-1");
    public BsCssBuilder FlexExtraExtraLargeShrink0 => AddClass("flex-xxl-shrink-0");
    public BsCssBuilder FlexExtraExtraLargeShrink1 => AddClass("flex-xxl-shrink-1");
    
    // Wrap
    public BsCssBuilder FlexNowrap => AddClass("flex-nowrap");
    public BsCssBuilder FlexSmallNowrap => AddClass("flex-sm-nowrap");
    public BsCssBuilder FlexMediumNowrap => AddClass("flex-md-nowrap");
    public BsCssBuilder FlexLargeNowrap => AddClass("flex-lg-nowrap");
    public BsCssBuilder FlexExtraLargeNowrap => AddClass("flex-xl-nowrap");
    public BsCssBuilder FlexExtraExtraLargeNowrap => AddClass("flex-xxl-nowrap");
    
    public BsCssBuilder FlexWrap => AddClass("flex-wrap");
    public BsCssBuilder FlexSmallWrap => AddClass("flex-sm-wrap");
    public BsCssBuilder FlexMediumWrap => AddClass("flex-md-wrap");
    public BsCssBuilder FlexLargeWrap => AddClass("flex-lg-wrap");
    public BsCssBuilder FlexExtraLargeWrap => AddClass("flex-xl-wrap");
    public BsCssBuilder FlexExtraExtraLargeWrap => AddClass("flex-xxl-wrap");
    
    public BsCssBuilder FlexWrapReverse => AddClass("flex-wrap-reverse");
    public BsCssBuilder FlexSmallWrapReverse => AddClass("flex-sm-wrap-reverse");
    public BsCssBuilder FlexMediumWrapReverse => AddClass("flex-md-wrap-reverse");
    public BsCssBuilder FlexLargeWrapReverse => AddClass("flex-lg-wrap-reverse");
    public BsCssBuilder FlexExtraLargeWrapReverse => AddClass("flex-xl-wrap-reverse");
    public BsCssBuilder FlexExtraExtraLargeWrapReverse => AddClass("flex-xxl-wrap-reverse");
    
    // Order
    public BsCssBuilder Order0 => AddClass("order-0");
    public BsCssBuilder Order1 => AddClass("order-1");
    public BsCssBuilder Order2 => AddClass("order-2");
    public BsCssBuilder Order3 => AddClass("order-3");
    public BsCssBuilder Order4 => AddClass("order-4");
    public BsCssBuilder Order5 => AddClass("order-5");
    
    public BsCssBuilder OrderSmall0 => AddClass("order-sm-0");
    public BsCssBuilder OrderSmall1 => AddClass("order-sm-1");
    public BsCssBuilder OrderSmall2 => AddClass("order-sm-2");
    public BsCssBuilder OrderSmall3 => AddClass("order-sm-3");
    public BsCssBuilder OrderSmall4 => AddClass("order-sm-4");
    public BsCssBuilder OrderSmall5 => AddClass("order-sm-5");
    
    public BsCssBuilder OrderMedium0 => AddClass("order-md-0");
    public BsCssBuilder OrderMedium1 => AddClass("order-md-1");
    public BsCssBuilder OrderMedium2 => AddClass("order-md-2");
    public BsCssBuilder OrderMedium3 => AddClass("order-md-3");
    public BsCssBuilder OrderMedium4 => AddClass("order-md-4");
    public BsCssBuilder OrderMedium5 => AddClass("order-md-5");
    
    public BsCssBuilder OrderLarge0 => AddClass("order-lg-0");
    public BsCssBuilder OrderLarge1 => AddClass("order-lg-1");
    public BsCssBuilder OrderLarge2 => AddClass("order-lg-2");
    public BsCssBuilder OrderLarge3 => AddClass("order-lg-3");
    public BsCssBuilder OrderLarge4 => AddClass("order-lg-4");
    public BsCssBuilder OrderLarge5 => AddClass("order-lg-5");
    
    public BsCssBuilder OrderExtraLarge0 => AddClass("order-xl-0");
    public BsCssBuilder OrderExtraLarge1 => AddClass("order-xl-1");
    public BsCssBuilder OrderExtraLarge2 => AddClass("order-xl-2");
    public BsCssBuilder OrderExtraLarge3 => AddClass("order-xl-3");
    public BsCssBuilder OrderExtraLarge4 => AddClass("order-xl-4");
    public BsCssBuilder OrderExtraLarge5 => AddClass("order-xl-5");
    
    public BsCssBuilder OrderExtraExtraLarge0 => AddClass("order-xxl-0");
    public BsCssBuilder OrderExtraExtraLarge1 => AddClass("order-xxl-1");
    public BsCssBuilder OrderExtraExtraLarge2 => AddClass("order-xxl-2");
    public BsCssBuilder OrderExtraExtraLarge3 => AddClass("order-xxl-3");
    public BsCssBuilder OrderExtraExtraLarge4 => AddClass("order-xxl-4");
    public BsCssBuilder OrderExtraExtraLarge5 => AddClass("order-xxl-5");
    
    // Order First and Last
    public BsCssBuilder OrderFirst => AddClass("order-first");
    public BsCssBuilder OrderLast => AddClass("order-last");
    public BsCssBuilder OrderSmallFirst => AddClass("order-sm-first");
    public BsCssBuilder OrderSmallLast => AddClass("order-sm-last");
    public BsCssBuilder OrderMediumFirst => AddClass("order-md-first");
    public BsCssBuilder OrderMediumLast => AddClass("order-md-last");
    public BsCssBuilder OrderLargeFirst => AddClass("order-lg-first");
    public BsCssBuilder OrderLargeLast => AddClass("order-lg-last");
    public BsCssBuilder OrderExtraLargeFirst => AddClass("order-xl-first");
    public BsCssBuilder OrderExtraLargeLast => AddClass("order-xl-last");
    public BsCssBuilder OrderExtraExtraLargeFirst => AddClass("order-xxl-first");
    public BsCssBuilder OrderExtraExtraLargeLast => AddClass("order-xxl-last");
    
    // Align content
    public BsCssBuilder AlignContentStart => AddClass("align-content-start");
    public BsCssBuilder AlignContentSmallStart => AddClass("align-content-sm-start");
    public BsCssBuilder AlignContentMediumStart => AddClass("align-content-md-start");
    public BsCssBuilder AlignContentLargeStart => AddClass("align-content-lg-start");
    public BsCssBuilder AlignContentExtraLargeStart => AddClass("align-content-xl-start");
    public BsCssBuilder AlignContentExtraExtraLargeStart => AddClass("align-content-xxl-start");
    
    public BsCssBuilder AlignContentEnd => AddClass("align-content-end");
    public BsCssBuilder AlignContentSmallEnd => AddClass("align-content-sm-end");
    public BsCssBuilder AlignContentMediumEnd => AddClass("align-content-md-end");
    public BsCssBuilder AlignContentLargeEnd => AddClass("align-content-lg-end");
    public BsCssBuilder AlignContentExtraLargeEnd => AddClass("align-content-xl-end");
    public BsCssBuilder AlignContentExtraExtraLargeEnd => AddClass("align-content-xxl-end");
    
    public BsCssBuilder AlignContentCenter => AddClass("align-content-center");
    public BsCssBuilder AlignContentSmallCenter => AddClass("align-content-sm-center");
    public BsCssBuilder AlignContentMediumCenter => AddClass("align-content-md-center");
    public BsCssBuilder AlignContentLargeCenter => AddClass("align-content-lg-center");
    public BsCssBuilder AlignContentExtraLargeCenter => AddClass("align-content-xl-center");
    public BsCssBuilder AlignContentExtraExtraLargeCenter => AddClass("align-content-xxl-center");
    
    public BsCssBuilder AlignContentBetween => AddClass("align-content-between");
    public BsCssBuilder AlignContentSmallBetween => AddClass("align-content-sm-between");
    public BsCssBuilder AlignContentMediumBetween => AddClass("align-content-md-between");
    public BsCssBuilder AlignContentLargeBetween => AddClass("align-content-lg-between");
    public BsCssBuilder AlignContentExtraLargeBetween => AddClass("align-content-xl-between");
    public BsCssBuilder AlignContentExtraExtraLargeBetween => AddClass("align-content-xxl-between");
    
    public BsCssBuilder AlignContentAround => AddClass("align-content-around");
    public BsCssBuilder AlignContentSmallAround => AddClass("align-content-sm-around");
    public BsCssBuilder AlignContentMediumAround => AddClass("align-content-md-around");
    public BsCssBuilder AlignContentLargeAround => AddClass("align-content-lg-around");
    public BsCssBuilder AlignContentExtraLargeAround => AddClass("align-content-xl-around");
    public BsCssBuilder AlignContentExtraExtraLargeAround => AddClass("align-content-xxl-around");
    
    public BsCssBuilder AlignContentStretch => AddClass("align-content-stretch");
    public BsCssBuilder AlignContentSmallStretch => AddClass("align-content-sm-stretch");
    public BsCssBuilder AlignContentMediumStretch => AddClass("align-content-md-stretch");
    public BsCssBuilder AlignContentLargeStretch => AddClass("align-content-lg-stretch");
    public BsCssBuilder AlignContentExtraLargeStretch => AddClass("align-content-xl-stretch");
    public BsCssBuilder AlignContentExtraExtraLargeStretch => AddClass("align-content-xxl-stretch");
    
}
